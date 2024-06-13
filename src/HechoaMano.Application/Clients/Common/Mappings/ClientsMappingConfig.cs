using HechoaMano.Domain.Clients;
using Mapster;

namespace HechoaMano.Application.Clients.Common.Mappings;

public class ClientsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Client, ClientResult>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.City, src => src.ContactInfo.City);
    }
}
