using Domain_Layer.Dtos;
using Domain_Layer.Queries;
using Domain_Layer.Queries.Sistemas;
using System;

namespace TestApp
{
    class Program
    {
        

        static void Main(string[] args)
        {
            IDSistemaQuery query = new DQuery();
            var resp = query.Listar(new DSistemaDto());
            foreach (DSistemaDto dto in resp)
            {
                Console.WriteLine(dto.Nombre);
                Console.WriteLine(dto.Abreviatura);
            }
            //Console.WriteLine(resp.Nombre);
            Console.ReadLine();
        }
    }
}