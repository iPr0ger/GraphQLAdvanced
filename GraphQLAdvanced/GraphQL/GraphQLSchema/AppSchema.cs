using System;
using GraphQL.Types;
using GraphQLAdvanced.GraphQL.GraphQLQueries;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLAdvanced.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();        
            Mutation = provider.GetRequiredService<AppMutation>();
        }
    }
}