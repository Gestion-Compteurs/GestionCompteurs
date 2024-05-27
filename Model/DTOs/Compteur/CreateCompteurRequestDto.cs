﻿namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Compteur;

public class CreateCompteurRequestDto
{
    public string Marque { get; set; } = string.Empty;
    public string Modele { get; set; } = string.Empty;
    public int AnneeCreation { get; set; } = 0;
    public int VoltageMax { get; set; } = 0;
}