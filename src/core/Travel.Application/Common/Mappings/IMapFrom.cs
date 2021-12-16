using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Application.Common.Mapping
{
    public interface ImapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
