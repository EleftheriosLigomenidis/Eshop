using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<Tentity> where Tentity : BaseEntity
    {
        public static IQueryable<Tentity> GetQuery(IQueryable<Tentity> inputQuery,
            ISpecification<Tentity> spec)
        {
            var query = inputQuery; //storing input query

            // evaluating whats inside spec

            if(spec.Criteria!= null)
            {
                query = query.Where(spec.Criteria); // lamda expression p => p.id == ID 
            }
            // our Includes is an aggregate of all includes accumulating into an expression
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            // () takes 2 parameters current represents the entity we are passing 
            // include the expression of our current statement
            return query;
        }
    }
}
