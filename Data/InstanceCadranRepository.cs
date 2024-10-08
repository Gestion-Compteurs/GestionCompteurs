﻿using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.ReleveCadran;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionCompteursElectriquesMoyenneTension.Data;


public class InstanceCadranRepository:IInstanceCadranRepository
{
    private readonly ApplicationDbContext _context;
    public InstanceCadranRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<InstanceCadran>> GetAllAsync()
    {
        return await _context.InstanceCadrans.AsNoTracking().ToListAsync();
    }

    public async Task<InstanceCadran?> GetByIdAsync(int id)
    {
        var instanceCadran = await _context.InstanceCadrans.FirstOrDefaultAsync(c=>c.InstanceCadranId == id);
        return instanceCadran ;
    }

    
    public async Task<InstanceCadran?> CreateAsync(InstanceCadran instanceCadranModel)
    {
        await _context.InstanceCadrans.AddAsync(instanceCadranModel);
        await _context.SaveChangesAsync();
        return instanceCadranModel;
    }

    public async Task<bool> InstanceCadranExists(int id)
    {
        return await _context.InstanceCadrans.AnyAsync(s => s.InstanceCadranId == id);
    }
}