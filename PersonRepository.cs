using System.Linq.Expressions;
using Umbraco.Cms.Core.Models;
using Umbraco.UIBuilder;
using Umbraco.UIBuilder.Persistence;

namespace test;

//None of the NotImplemented will ever be hit
public class PersonRepository : Repository<Person, int>
{
    public PersonRepository(RepositoryContext context) : base(context)
    {
    }

    protected override int GetIdImpl(Person entity)
    {
        return entity.Id;
    }

    protected override Person GetImpl(int id)
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<TJunctionEntity> GetRelationsByParentIdImpl<TJunctionEntity>(int parentId, string relationAlias)
    {
        throw new NotImplementedException();
    }

    protected override Person SaveImpl(Person entity)
    {
        //This is a good place to put a breakpoint although the save action will fail before it reaches this method
        throw new NotImplementedException();
    }

    protected override TJunctionEntity SaveRelationImpl<TJunctionEntity>(TJunctionEntity entity)
    {
        throw new NotImplementedException();
    }

    protected override void DeleteImpl(int id)
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<Person> GetAllImpl(Expression<Func<Person, bool>>? whereClause = null, Expression<Func<Person, object>>? orderBy = null,
        SortDirection orderByDirection = SortDirection.Ascending)
    {
        throw new NotImplementedException();
    }

    protected override PagedResult<Person> GetPagedImpl(int pageNumber, int pageSize, Expression<Func<Person, bool>>? whereClause = null, Expression<Func<Person, object>>? orderBy = null,
        SortDirection orderByDirection = SortDirection.Ascending)
    {
        return new PagedResult<Person>(0, 1, 30)
        {
            Items = new List<Person>()
        };
    }

    protected override long GetCountImpl(Expression<Func<Person, bool>> whereClause)
    {
        return 0;
    }
}
