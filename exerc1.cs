using System;

public class ConexaoBanco
{
   private static ConexaoBanco instance;

   private ConexaoBanco() {}

   public static ConexaoBanco Instance
   {
      get
      {
         if (instance == null)
         {
            instance = new ConexaoBanco();
         }
         return instance;
      }
   }
}

public static Main(string[] args){

    ConexaoBanco conect = ConexaoBanco.ConexaoBanco();
    
}