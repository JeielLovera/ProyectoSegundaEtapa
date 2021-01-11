using System.Collections.Generic;

namespace Proyecto.Infrastructure.Context.Configuration
{
    public static class Utilities
    {
        public static int cursosCount = 15;

        public static int GetCursoId(string nombre)
        {
            Dictionary<string, int> cursosDictionary = new Dictionary<string, int>(){
                { "Education", 1},
                { "Applied Arts", 2},
                { "Humanities & Social Sciences", 3 },
                { "Mass Communication", 4},
                { "Accountancy", 5},
                {"Business & Administration", 6 },
                {"Law", 7 },
                {"Natural Physical & Mathematical Sciences", 8 },
                {"Medicine", 9 },
                {"Dentistry", 10 },
                {"Health Sciences", 11 },
                {"Information Technology", 12 },
                {"Architecture & Building", 13 },
                {"Engineering Sciences", 14 },
                {"Services", 15 }
            };

            return cursosDictionary[nombre];
        }

        public static string GetCursoName(int id)
        {
            Dictionary<int, string> cursosDictionary = new Dictionary<int, string>(){
                { 1, "Education"},
                { 2, "Applied Arts"},
                { 3, "Humanities & Social Sciences" },
                { 4, "Mass Communication"},
                { 5, "Accountancy"},
                { 6, "Business & Administration" },
                { 7, "Law" },
                { 8, "Natural Physical & Mathematical Sciences" },
                { 9, "Medicine" },
                { 10, "Dentistry" },
                { 11, "Health Sciences" },
                { 12, "Information Technology" },
                { 13, "Architecture & Building" },
                { 14, "Engineering Sciences" },
                { 15, "Services" }
            };

            return cursosDictionary[id];
        }
    }
}
