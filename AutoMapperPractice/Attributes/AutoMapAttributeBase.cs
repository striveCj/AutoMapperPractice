﻿using System;
using AutoMapper;

namespace AutoMapperPractice.Attributes
{
    /// <inheritdoc />
    /// <summary>
    /// AutoMap继承基类，此类无法继承扩展类需要基层此类
    /// </summary>
    public abstract class AutoMapAttributeBase:Attribute
    {
        public Type[] TargeTypes { get; private set; }

        protected AutoMapAttributeBase(params Type[] targetTypes)
        {
            TargeTypes = targetTypes;
        }

        public abstract void CreateMap(IMapperConfigurationExpression configuration, Type type);
    }
}
