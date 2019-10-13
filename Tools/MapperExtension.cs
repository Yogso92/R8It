using System;
using System.Linq;
using System.Reflection;

namespace Tools
{
    public static class MapperExtension //mapper de khun, POCO2POCO
    {
        // Création d'une méthode d'extension pour tous les objets
        public static T Map<T>(this object o)
            // On s'assure que la classe T possede un constructeur vide
            where T : new()
        {
            // Récupération de toutes les propiétés de la class T
            PropertyInfo[] props = typeof(T).GetProperties();
            // Récupération du ctor vide de la class T
            ConstructorInfo ctor = typeof(T)
                .GetConstructor(new Type[0]);
            // instanciation d'un objet T sans paramètre
            T result = (T)ctor?.Invoke(new object[0]);
            // Parcourt toutes les propriétés de la class T
            foreach (var prop in props.Where(p => p.CanWrite))
            {
                // Recherche d'une prop dans l'objet de départ qui possède un nom identique 
                var currentProp = o.GetType().GetRuntimeProperty(prop.Name);
                // si la propriété existe
                if (currentProp != null)
                {

                    try
                    {
                        // récupération de la valeur de cette prop dans l'objet de départ
                        object value = currentProp.GetValue(o);

                        // affectation de cette valeur dans l'objet de destination T
                        prop.SetValue(result, value);
                    }
                    catch (Exception)
                    {

                    }


                }
            }
            return result;
        }
    }
}
