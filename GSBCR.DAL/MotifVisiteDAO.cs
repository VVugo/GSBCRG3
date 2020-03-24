﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSBCR.modele;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace GSBCR.DAL
{
    public class MotifVisiteDAO
    {
        public MOTIF_VISITE FindById(string code)
        {
            //Rechercher un motif visite par son nom
            MOTIF_VISITE lmv = null;
            using (var context = new GSB_VisiteEntities())
            {
                var req = from m in context.MOTIF_VISITE.Include("LesRapports")
                          where m.MOT_LIBEL == code
                          select m;
                lmv = req.SingleOrDefault<MOTIF_VISITE>();
            }
            return lmv;
        }

        public List<MOTIF_VISITE> FindAll()
        {
            List<MOTIF_VISITE> lmv = null;
            using (var context = new GSB_VisiteEntities())
            {
                //désactiver le chargement différé
                //context.Configuration.LazyLoadingEnabled = false;
                var req = from m in context.MOTIF_VISITE.Include("LesRapports")
                          select m;
                lmv = req.ToList<MOTIF_VISITE>();

            }
            return lmv;
        }
    }
}
