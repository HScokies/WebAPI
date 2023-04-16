using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Entities;
using WebAPI.Services.Interfaces;
namespace WebAPI.Services
{
    public class CMDs : ICMDs
    {
        private readonly AppDbContext ctx;

        public CMDs(AppDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task Drop(int id)
        {
            var res = await ctx.entity.FirstOrDefaultAsync(e => e.id == id);
            if (res is null) throw new NullReferenceException("Not Found!");
            ctx.entity.Remove(res);
            await ctx.SaveChangesAsync();
        }

        public async Task<SampleModel> Get(int id)
        {
            var res = await ctx.entity.FirstOrDefaultAsync(e => e.id == id);
            if (res is null) throw new NullReferenceException("Not Found!");
            return res;
        }

        public async Task<SampleModel> Insert(In_SampleModel Entity)
        {
           var ent = Entity.AutoMap<In_SampleModel, SampleModel>();
           var res = await ctx.entity.AddAsync(ent);
           await ctx.SaveChangesAsync();
           return res.Entity;
        }

        public async Task<SampleModel> Update(int id, In_SampleModel newEntity)
        {
            var res = await ctx.entity.FirstOrDefaultAsync(e => e.id == id);
            if (res is null) throw new NullReferenceException("Not Found!");
            Mapper.Remap(res, newEntity);
            await ctx.SaveChangesAsync();
            return res; 
        }
    }
}