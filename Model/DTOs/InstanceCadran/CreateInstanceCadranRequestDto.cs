namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCadran;

public class CreateInstanceCadranRequestDto
{
    //Rien a donner sauf le modele du cadran qui est [FromRoute] resultant du choix du modèle cadran (string) 
    // public int CadranId { get; set; }
   public int InstanceCompteurId { get; set;}
}