using System.Globalization;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;
using Dominio.Entities;
using Microsoft.Extensions.Logging;

namespace Persistencia;
public class ApiContextSeed
{
    public static async Task SeedAsync(ApiContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            //inicio de las insersiones en la db
            /* var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); */

            /*  if (!context.Usuarios.Any())
             {
                 using (var reader = new StreamReader(ruta + @"/Data/Csv/User.csv"))
                 {
                     using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                     {
                         var list = csv.GetRecords<Usuario>();
                         context.Usuarios.AddRange(list);
                         await context.SaveChangesAsync();
                     }
                 }

             } */

            if (!context.Usuarios.Any())
            {

                using (var readerUsuario = new StreamReader("../Persistencia/Data/Csvs/User.csv"))
                {
                    using (var csv = new CsvReader(readerUsuario, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<Usuario>();
                        context.Usuarios.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            /* 
                        if (!context.RolUsuarios.Any())
                        {
                            using (var reader = new StreamReader(ruta + @"\Data\Csv\RoleUser.csv"))
                            {
                                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                                {
                                    HeaderValidated = null, // Esto deshabilita la validación de encabezados
                                    MissingFieldFound = null
                                }))
                                {
                                    // Resto de tu código para leer y procesar el archivo CSV
                                    var list = csv.GetRecords<RolUsuario>();
                                    List<RolUsuario> entidad = new List<RolUsuario>();
                                    foreach (var item in list)
                                    {
                                        entidad.Add(new RolUsuario
                                        {
                                            IdUsuarioFk = item.IdUsuarioFk,
                                            IdRolFk = item.IdRolFk
                                        });
                                    }
                                    context.RolUsuarios.AddRange(entidad);
                                    await context.SaveChangesAsync();
                                }
                            }
                        } */

            if (!context.Roles.Any())
            {
                var roles = new List<Rol>()
                        {
                            new Rol{Id=1, Nombre="Administrador"},
                            new Rol{Id=2, Nombre="Empleado"},
                        };
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }

            if (!context.RolUsuarios.Any())
            {

                using (var readerRolUsuario = new StreamReader("../Persistencia/Data/Csvs/RoleUser.csv"))
                {
                    /* using (var csv = new CsvReader(readerRolUsuario, CultureInfo.InvariantCulture)) */
                    using (var csv = new CsvReader(readerRolUsuario, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<RolUsuario>();

                        List<RolUsuario> entidad = new List<RolUsuario>();
                        foreach (var item in list)
                        {
                            entidad.Add(new RolUsuario
                            {
                                IdUsuarioFk = item.IdUsuarioFk,
                                IdRolFk = item.IdRolFk
                            });
                        }

                        context.RolUsuarios.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            /* if (!context.Quotes.Any())
            {
                using (var readerQuote = new StreamReader("../Persistence/Data/Csvs/Quote.csv"))
                {
                    using (var csv = new CsvReader(readerQuote, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<Quote>();

                        List<Quote> entidad = new List<Quote>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Quote
                            {
                                Id = item.Id,
                                Date = item.Date,
                                Hour = item.Hour,
                                Reason = item.Reason,
                                PetIdFk = item.PetIdFk,
                                VeterinarianIdFk = item.VeterinarianIdFk,
                            });
                        }

                        context.Quotes.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            } */
            //fin de las insersiones en la db
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiContext>();
            logger.LogError(ex.Message);
        }
    }
    public static async Task SeedRolesAsync(ApiContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Rol>()
                        {
                            new Rol{Id=1, Nombre="Administrador"},
                            new Rol{Id=2, Nombre="Empleado"},
                        };
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiContext>();
            logger.LogError(ex.Message);
        }
    }
}
