using HechoaMano.Domain.Clients;
using Mapster;

namespace HechoaMano.Application.Clients.Common.Mappings;

public class ClientsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Client, ClientResult>()
            .Map(dest => dest.Id, source => source.Id.Value);
            

        config.NewConfig<Client, ClientNamesResult>()
            .Map(dest => dest.Id, source => source.Id.Value);
    }
}
