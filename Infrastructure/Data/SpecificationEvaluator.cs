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

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy); // lamda expression p => p.id == ID 
            }

            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending); // lamda expression p => p.id == ID 
            }

            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
                // PAGING SHOULD COME LAST 
                // if we page first we would not filter the whole set but the paged only
            }
            // our Includes is an aggregate of all includes accumulating into an expression
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            // () takes 2 parameters current represents the entity we are passing 
            // include the expression of our current statement
            return query;
        }
    }
}
