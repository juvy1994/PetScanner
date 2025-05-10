using Bogus;

using PS.Infrastructure.Shared;

namespace PS.Infrastructure.Mocks
{
    public static class PetBreedInfoMockGenerator
    {
        public static PetBreedInfoDto Generate(string? breed = null, string? especie = null)
        {
            var faker = new Faker("es");

            especie ??= faker.PickRandom("gato", "perro");
            breed ??= especie == "gato"
                ? faker.PickRandom(BreedData.RazasGatos)
                : faker.PickRandom(BreedData.RazasPerros);

            var enfermedades = new[]
            {
                new PetBreedInfoDto.EnfermedadComun
                {
                    nombre = "Displasia de cadera",
                    descripcion = "Malformación en la articulación de la cadera",
                    prevencion = "Evitar sobrepeso y actividad física controlada"
                },
                new PetBreedInfoDto.EnfermedadComun
                {
                    nombre = "Otitis",
                    descripcion = "Inflamación del oído externo o interno",
                    prevencion = "Limpieza semanal y revisiones veterinarias"
                },
                new PetBreedInfoDto.EnfermedadComun
                {
                    nombre = "Problemas renales",
                    descripcion = "Insuficiencia renal crónica",
                    prevencion = "Buena hidratación y chequeos anuales"
                },
                new PetBreedInfoDto.EnfermedadComun
                {
                    nombre = "Alergias alimentarias",
                    descripcion = "Reacción a ciertos componentes de su dieta",
                    prevencion = "Control veterinario y dieta hipoalergénica"
                }
            };

            return new Faker<PetBreedInfoDto>()
                .RuleFor(p => p.nombre_raza, _ => breed)
                .RuleFor(p => p.especie, _ => especie)
                .RuleFor(p => p.origen, f => f.Address.Country())
                .RuleFor(p => p.comportamiento, f => f.PickRandom(
                    "Amigable y leal", "Independiente y curioso", "Juguetón y energético",
                    "Protector y territorial", "Cariñoso con la familia", "Silencioso y observador"))
                .RuleFor(p => p.caracteristicas_fisicas, f => new PetBreedInfoDto.CaracteristicasFisicas
                {
                    tamano = f.PickRandom("Pequeño", "Mediano", "Grande"),
                    peso = $"{f.Random.Double(2.5, 40):0.0} kg",
                    esperanza_vida = $"{f.Random.Int(8, 18)} años",
                    pelaje = f.PickRandom("Corto", "Largo", "Rizado", "Sedoso", "Duro")
                })
                .RuleFor(p => p.alimentacion, f => new PetBreedInfoDto.Alimentacion
                {
                    tipo_recomendada = f.PickRandom("Balanceado seco", "Comida húmeda", "Dieta BARF", "Mixta"),
                    porciones = $"{f.Random.Int(50, 300)} g",
                    frecuencia = f.PickRandom("1 vez al día", "2 veces al día", "3 veces al día")
                })
                .RuleFor(p => p.cuidados_especiales, f => new PetBreedInfoDto.CuidadosEspeciales
                {
                    ejercicio = f.PickRandom("Paseos diarios", "Juguetes interactivos", "Carreras en parque"),
                    socializacion = f.PickRandom("Necesita interacción frecuente", "Sociable con humanos", "Ideal para niños", "Cauteloso con extraños")
                })
                .RuleFor(p => p.enfermedades_comunes, f => f.PickRandom(enfermedades, f.Random.Int(1, 3)).ToList())
                .RuleFor(p => p.UrlImage, _ => $"https://fakepets.com/images/{breed.Replace(" ", "_").ToLower()}.jpg")
                .Generate();
        }
    }
}
