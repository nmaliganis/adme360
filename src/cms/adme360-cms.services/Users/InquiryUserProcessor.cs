using System.Threading.Tasks;
using adme360.cms.contracts.Users;
using adme360.cms.repository.ContractRepositories;
using adme360.common.dtos.Vms.Users;
using adme360.common.infrastructure.TypeMappings;

namespace adme360.cms.services.Users
{
    public class InquiryUserProcessor : IInquiryUserProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IUserRepository _userRepository;
        public InquiryUserProcessor(IUserRepository userRepository, IAutoMapper autoMapper)
        {
            _userRepository = userRepository;
            _autoMapper = autoMapper;
        }

        public Task<UserUiModel> GetUserByLoginAsync(string login)
        {
            return Task.Run(() => _autoMapper.Map<UserUiModel>(_userRepository.FindUserByLogin(login)));
        }

        public Task<UserForRetrievalUiModel> GetAuthUserByLoginAsync(string login)
        {
            return Task.Run(() => _autoMapper.Map<UserForRetrievalUiModel>(_userRepository.FindUserByLogin(login)));
        }
    }
}