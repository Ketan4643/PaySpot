using System.Data;
namespace PayspotAPI.Services;
public class AdminService : IAdminService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly UserManager<AppUser> _userManager;
    public AdminService(IUnitOfWork unitOfWork, IMapper mapper, DataContext context, UserManager<AppUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = context;
        _userManager = userManager;
    }

    public async Task<ICollection<QueryDto>> GetQueries(RequestParams requestParams)
    {
        // var queries = await _unitOfWork.Leads.GetAll();

        // var queries = await _unitOfWork.Leads.GetPagedList(requestParams);
        var queries = await _unitOfWork.Leads.GetAll();
        var result = _mapper.Map<IList<QueryDto>>(queries);
        return result;
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

        if (validateLead != null)
            return new CommonResponseDto((int)StatusCodes.Status400BadRequest, "Email/ Mobile already registered", "");
        // if(validateLead) return false;
        await _unitOfWork.Leads.Insert(lead);
        await _unitOfWork.Save();

        // _context.Leads.Add(lead);
        // await _context.SaveChangesAsync();
        var result = await _unitOfWork.Leads.Get(q => q.Email == dto.Email);
        if (result != null) return new CommonResponseDto((int)StatusCodes.Status202Accepted, "Request Submitted Successfully", "You will get a callback"); ;
        // if(await _context.SaveChangesAsync() > 0) return true;
        return new CommonResponseDto((int)StatusCodes.Status500InternalServerError, "Something went wrong", "Please try after sometime");
        // return false;
    }

    public async Task<CommonResponseDto> UpdateAddressAsync(AddressDto dto)
    {
        CommonResponseDto responseDto = new CommonResponseDto(statusCode: StatusCodes.Status404NotFound);
        var user = await _context.Users.Where(x => x.Id == dto.UserId)
            .Include(a => a.AddressDetails)
            .FirstOrDefaultAsync();

        if (user == null) return responseDto = new CommonResponseDto(
            StatusCodes.Status400BadRequest,
            "User not found"
        );

        var existingAddress = user.AddressDetails
            .Where(x => x.IsCurrentAddress && x.AddressType == dto.AddressType).ToList();
        if (existingAddress != null)
        {
            foreach (var address in existingAddress)
            {
                address.IsCurrentAddress = false;
            }
        }
        user.AddressDetails.Add(new AddressDetail
        {
            AppUserId = dto.UserId,
            AddressType = dto.AddressType,
            AddressStatus = dto.AddressStatus,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            Address = dto.Address,
            City = dto.City,
            Pincode = dto.Pincode,
            StateCode = dto.StateCode,
            NoOfPerson = dto.NoOfPerson,
            IsCurrentAddress = true
        });
        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return new CommonResponseDto(StatusCodes.Status201Created,user.UserName,"Detail Updated");
    }

    public Task<CommonResponseDto> UpdateKycDocumentsAsync(KycDocumentDto dto)
    {
        throw new NotImplementedException();
    }
}