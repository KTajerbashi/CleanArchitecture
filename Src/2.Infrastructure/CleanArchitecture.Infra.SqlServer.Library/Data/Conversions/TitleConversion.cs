using CleanArchitecture.Core.Domain.Library.Common;
using CleanArchitecture.Core.Domain.Library.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArchitecture.Infra.SqlServer.Library.Data.Conversions;

public class TitleConversion : ValueConverter<Title, string>
{
    public TitleConversion() : base(c => c.Value, c => Title.FromString(c))
    {

    }
}
public class DescriptionConversion : ValueConverter<Description, string>
{
    public DescriptionConversion() : base(c => c.Value, c => Description.FromString(c))
    {

    }
}

public class EntityIdConversion : ValueConverter<EntityId, Guid>
{
    public EntityIdConversion() : base(c => c.Value, c => EntityId.FromGuid(c))
    {

    }
}