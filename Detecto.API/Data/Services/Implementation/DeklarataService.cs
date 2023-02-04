using AutoMapper;
using Detecto.API.Configurations;
using Detecto.API.Data.DTOs;
using Detecto.API.Data.Models;
using Detecto.API.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Data.Services.Implementation
{
    public class DeklarataService : IDeklarataService
    {
        private readonly DetectoDbContext _context;
        private readonly IMapper _mapper;

        public DeklarataService(DetectoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<DeklarataDTO>>> GetDeklaratat() =>
            _mapper.Map<List<DeklarataDTO>>(await _context.Deklaratat.ToListAsync());

        public async Task<ActionResult<DeklarataDTO>> GetDeklarataById(int id)
        {
            var mappedDeklarata = _mapper.Map<DeklarataDTO>(await _context.Deklaratat.FindAsync(id));
            return mappedDeklarata == null 
                ? new NotFoundObjectResult("Deklarata nuk ekziston!!")
                : new OkObjectResult(mappedDeklarata);
        }

        public async Task<ActionResult<List<DeklarataDTO>>> GetDeklaratatEPersonit(int id)
        {
            var dbPersoni = await _context.Personat.FindAsync(id);
            return dbPersoni == null
                ? new NotFoundObjectResult("Personi nuk ekziston!!")
                : _mapper.Map<List<DeklarataDTO>>(await _context.Deklaratat
                                .Where(p => p.Personi.Id == id)
                                .ToListAsync());
        }

        public async Task<ActionResult<string>> GetPerbajtjaEDeklarates(int id)
        {
            var dbPermbajtja = await _context.Deklaratat.FindAsync(id);
            return dbPermbajtja == null
                ? new NotFoundObjectResult("Deklarata nuk ekziston!!")
                : dbPermbajtja.Permbajtja;
        }

        public async Task<ActionResult> AddDeklarata(DeklarataDTO deklarataDTO)
        {
            if (deklarataDTO == null)
                return new BadRequestObjectResult("Deklarata nuk mund të jetë null!!");
            var mappedDeklarata = _mapper.Map<Deklarata>(deklarataDTO);
            await _context.Deklaratat.AddAsync(mappedDeklarata);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Deklarata u shtua me sukses!");
        }

        public async Task<ActionResult> UpdateDeklarata(int id, UpdateDeklarataDTO updateDeklarataDTO)
        {
            if (updateDeklarataDTO == null)
                return new BadRequestObjectResult("Deklarata nuk mund të jetë null!!");

            var dbDeklarata = await _context.Deklaratat.FindAsync(id);
            if (dbDeklarata == null)
                return new NotFoundObjectResult("Deklarata nuk ekziston!!");

            dbDeklarata.KohaEMarrjes = updateDeklarataDTO.KohaEMarrjes ?? dbDeklarata.KohaEMarrjes;
            dbDeklarata.Permbajtja = updateDeklarataDTO.Permbajtja ?? dbDeklarata.Permbajtja;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Deklarata u përditësua me sukses!");
        }

        public async Task<ActionResult> DeleteDeklarata(int id)
        {
            var dbDeklarata = await _context.Deklaratat.FindAsync(id);
            if (dbDeklarata == null)
                return new NotFoundObjectResult("Deklarata nuk ekziston!!");

            _context.Deklaratat.Remove(dbDeklarata);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Deklarata u fshi me sukses!");
        }

        public async Task<string> Compare(int d1Id, int d2Id)
        {
            Deklarata d1 = await _context.Deklaratat.FindAsync(d1Id);
            Deklarata d2 = await _context.Deklaratat.FindAsync(d2Id);

            if (d1 == null)
                return "Deklarata e parë është e zbrazët!!";
            if (d2 == null)
                return "Deklarata e dytë është e zbrazët!!";

            var deklarata1 = (await GetPerbajtjaEDeklarates(d1Id)).Value;
            var deklarata2 = (await GetPerbajtjaEDeklarates(d2Id)).Value;
            
            if (d1.PersoniId != d2.PersoniId)
                return "Deklaratat nuk janë nga i njejti person!!";
            /*
             * // API request payload
            string API_KEY = "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";
            string endpoint = "https://api.openai.com/v1/models/text-davinci-002/engines/text-curie/jobs";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {API_KEY}");

            // Define the input for the API
            var input = new
            {
                prompt = "Compare the semantics of the following two strings:",
                strings = new[] { deklarata1, deklarata2 }
            };

            // Serialize the input to a JSON string
            var content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");

            // Make the API request
            var response = await client.PostAsync(endpoint, content);

            // Check if the API call was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content
                var responseContent = await response.Content.ReadAsStringAsync();

                // Deserialize the response content to a dynamic object
                dynamic responseData = JsonConvert.DeserializeObject(responseContent);

                // Extract the comparison result from the response
                bool isSemanticMatch = responseData.result;

                return (isSemanticMatch ? "The semantics of the two strings are the same." : "The semantics of the two strings are different.");
            }
            else
            {
                return ($"The API request failed with status code {(int)response.StatusCode}.");
            }
            */

            string[] str1Words = deklarata1.ToLower().Split(' ');
            string[] str2Words = deklarata2.ToLower().Split(' ');
            var uniqueWords = str2Words.Except(str1Words).ToList();

            return "Deklarata e parë -> " + deklarata1 + "\n"
                + "Dallimet e deklaratës së dytë nga ajo e para -> "
                + $"{String.Join(" ", uniqueWords)}";
        }
    }
}
