using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAdvanced.Entities;

namespace GraphQLAdvanced.Contracts
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId);
        Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds);
    }
}