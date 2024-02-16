﻿using ComplexFilters.Abstractions;
using ComplexFilters.Abstractions.Models;

namespace Kata.QueryBuilder.ComplexFilters.FilterComparators
{
    public class ContainsComparator : IComparator
    {
        public ContainsComparator()
        {
        }

        public FilterBuilder ComposeExpression(FilterBuilder filterBuilder, Filter filter)
        {
            filterBuilder.JoinExpression.Add(new Joiner()
            {
                FilterColumn = $"{filter.FilterColumn}",
                ValueToFilter = filter.FilterValue.SingleOrDefault()?.ToString() ?? "NULL",
                Operation = LogialComparator.Contains,
                LogicalOperator = filter.LogicalOperator
            });

            return filterBuilder;
        }


        public FilterBuilder ComposeExpression(FilterBuilder filterBuilder, Filter filter, string columnName)
        {
            filterBuilder.JoinExpression.Add(new Joiner()
            {
                FilterColumn = columnName,
                ValueToFilter = filter.FilterValue.SingleOrDefault()?.ToString() ?? "NULL",
                Operation = LogialComparator.Contains
            });

            return filterBuilder;
        }
    }
}
