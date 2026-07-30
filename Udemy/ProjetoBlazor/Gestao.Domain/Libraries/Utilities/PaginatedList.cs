using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Domain.Libraries.Utilities
{
    public class PaginatedList<T>
    {
        /* Exemplo:
         * 92 empresas existentes
         * Página 1: Registro 1 ao 10
         * Página 2: Registro 11 ao 20
         * Página ...
         * Página 10: Registro 91 ao 92
         */

        public List<T> Items { get; private set; } = new List<T>();  //Exemplo: 10 itens
        public int TotalPages { get; private set; } = 0;
        public int PageIndex { get; private set; } = 0;
        public bool HasNextPage => PageIndex < TotalPages;        
        public bool HasPreviousPage => PageIndex > 1;

        public PaginatedList(List<T> items, int pageIndex, int totalPages)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPages = totalPages;            
        }
    }
}
