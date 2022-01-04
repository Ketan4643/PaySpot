namespace PayspotAPI.Services;
public class AdminService : IAdminService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    public AdminService(IUnitOfWork unitOfWork,IMapper mapper, DataContext context)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = context;
    }

    public async Task<ICollection<QueryDto>> GetQueries()
    {
        // var queries = await _unitOfWork.Leads.GetAll();
        
        var queries = await _unitOfWork.Leads.GetAll();
        return _mapper.Map<List<QueryDto>>(queries);
    }

    public async Task<ICollection<StatesDto>> GetStates()
    {
        var states = await _unitOfWork.States.GetAll();
        var result = _mapper.Map<List<StatesDto>>(states);
        return result;
    }

    public async Task<CommonResponseDto> RegisterCallbackRequest(RegisterDto dto)
    {
        var lead = _mapper.Map<Lead>(dto);
        lead.CreatedOn = DateTime.Now;
        lead.PendingStatus = true;

        var validateLead = await _unitOfWork.Leads.Get(x => (x.Email == dto.Email || x.Mobile == dto.Mobile));
        // var validateLead = await _context.Leads.AnyAsync(x => x.Email == dto.Email);

        if(validateLead != null) 
            return new CommonResponseDto((int)StatusCodes.Status400BadRequest,"Email/ Mobile already registered","");
        // if(validateLead) return false;
        await _unitOfWork.Leads.Insert(lead);
        await _unitOfWork.Save();

        // _context.Leads.Add(lead);
        // await _context.SaveChangesAsync();
        var result = await _unitOfWork.Leads.Get(q => q.Email == dto.Email);
        if(result != null) return new CommonResponseDto((int)StatusCodes.Status202Accepted,"Request Submitted Successfully","You will get a callback");;
        // if(await _context.SaveChangesAsync() > 0) return true;
        return new CommonResponseDto((int)StatusCodes.Status500InternalServerError,"Something went wrong","Please try after sometime");
        // return false;
    }
}