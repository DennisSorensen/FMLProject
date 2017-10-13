﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FML.DBLayer
{
    public interface IDbCRUD<T>
    {
        //T er stand in for en hvilken som helst class, "entity" er pladsholder for navnet på instance af class T. 
        void Create(T entity);
        //T er stand in for hvilken som helst Class, int id er id for den specifikke instance af class "T" der ønskes fundet.
        T Get(int Id);
        //itererer over en collection af typen T ( måske giver den en liste af instance referencer?)
        IEnumerable<T> GetAll();
        // opdaterer instancen "entity" af class typen T
        void Update(T entity);
        //sletter en instance med id som er " int id"
        void Delete(int id);

    }
}
