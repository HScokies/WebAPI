using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Entities;

namespace WebAPI.Services.Interfaces
{
    public interface ICMDs
    {
       public Task<SampleModel> Insert(In_SampleModel Entity);
       public Task<SampleModel> Get(int id);
       public Task<SampleModel> Update(int id, In_SampleModel newEntity);
       public Task Drop(int id); 
    }
}