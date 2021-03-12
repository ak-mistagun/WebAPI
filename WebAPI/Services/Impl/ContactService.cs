using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebAPI.Mappings.Dto.Response;
using WebAPI.Repositories;

namespace WebAPI.Services.Impl
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository repository;
        private readonly IMapper mapper;

        public ContactService(IContactRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<ContactResponseDto> All()
        {
            return repository.All().Select(contact => mapper.Map<ContactResponseDto>(contact));
        }
    }
}