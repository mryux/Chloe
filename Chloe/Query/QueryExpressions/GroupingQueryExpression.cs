﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chloe.Query.QueryExpressions
{
    class GroupingQueryExpression : QueryExpression
    {
        List<LambdaExpression> _groupPredicates = new List<LambdaExpression>();
        List<LambdaExpression> _havingPredicates = new List<LambdaExpression>();
        LambdaExpression _selector;
        public GroupingQueryExpression(Type elementType, QueryExpression prevExpression, LambdaExpression selector)
            : base(QueryExpressionType.GroupingQuery, elementType, prevExpression)
        {
            this._selector = selector;
        }

        public List<LambdaExpression> GroupPredicates { get { return this._groupPredicates; } }
        public List<LambdaExpression> HavingPredicates { get { return this._havingPredicates; } }
        public LambdaExpression Selector { get { return this._selector; } }

        public override T Accept<T>(QueryExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
