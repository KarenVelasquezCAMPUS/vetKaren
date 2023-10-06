using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class MedicalTreatmentsRepository : IMedicalTreatments
{
    private readonly ApiVetKarenContext _context;

    public MedicalTreatmentsRepository(ApiVetKarenContext context)
    {
        _context = context;
    }

     public virtual void Add(MedicalTreatments entity)
    {
        _context.Set<MedicalTreatments>().Add(entity);
    }
    
    public virtual void AddRange(IEnumerable<MedicalTreatments> entities)
    {
        _context.Set<MedicalTreatments>().AddRange(entities);
    }

    public virtual IEnumerable<MedicalTreatments> Find(Expression<Func<MedicalTreatments, bool>> expression)
    {
        return _context.Set<MedicalTreatments>().Where(expression);
    }

    // Pag
        public virtual async Task<(int totalRegistros, IEnumerable<MedicalTreatments> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.MedicalTreatmentss as IQueryable<MedicalTreatments>;
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public virtual Task<MedicalTreatments> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(MedicalTreatments entity)
    {
        _context.Set<MedicalTreatments>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<MedicalTreatments> entities)
    {
        _context.Set<MedicalTreatments>().RemoveRange(entities);
    }

    public virtual void Update(MedicalTreatments entity)
    {
        _context.Set<MedicalTreatments>()
            .Update(entity);
    }
}