using AutoMapper;
using SoftcrylicTech.Library.Repositories.Interfaces;
using SoftcrylicTech.Library.Services.Interfaces;
using SoftcrylicTech.Model;
using System;
using System.Threading.Tasks;

namespace SoftcrylicTech.Library.Services
{
    public class TechConferenceService : ITechConferenceService
    {
        private readonly ITechConferenceRepo _techConferenceRepo;
        private readonly IMapper _mapper;
        public TechConferenceService(ITechConferenceRepo techConferenceRepo, IMapper mapper)
        {
            _techConferenceRepo = techConferenceRepo ?? throw new ArgumentNullException(nameof(techConferenceRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EventModel> GetEventAsync(string title)
        {
            try
            {
                var repoData = await _techConferenceRepo.GetEventAsync(title);
                return _mapper.Map<EventModel>(repoData);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public async Task<EventModel> SaveEventAsync(EventModel eventModel)
        {
            try
            {
                var repoData = await _techConferenceRepo.SaveEventAsync(eventModel);
                return _mapper.Map<EventModel>(repoData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EventModel> UpdateEventAsync(EventModel eventModel)
        {
            try
            {
                var repoData = await _techConferenceRepo.UpdateEventAsync(eventModel);
                return _mapper.Map<EventModel>(repoData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EventModel> DeleteEventAsync(int eventId)
        {
            try
            {
                var repoData = await _techConferenceRepo.DeleteEventAsync(eventId);
                return _mapper.Map<EventModel>(repoData);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SpeakerModel> SaveSpeakerAsync(SpeakerModel speakerModel)
        {
            try
            {
                var repoData = await _techConferenceRepo.SaveSpeakerAsync(speakerModel);
                return _mapper.Map<SpeakerModel>(repoData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
