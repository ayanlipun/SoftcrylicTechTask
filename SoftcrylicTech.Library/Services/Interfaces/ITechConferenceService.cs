using SoftcrylicTech.Model;
using System.Threading.Tasks;

namespace SoftcrylicTech.Library.Services.Interfaces
{
    public interface ITechConferenceService
    {
        Task<EventModel> GetEventAsync(string title);
        Task<EventModel> SaveEventAsync(EventModel eventModel);
        Task<EventModel> UpdateEventAsync(EventModel eventModel);
        Task<EventModel> DeleteEventAsync(int eventModel);
        Task<SpeakerModel> SaveSpeakerAsync(SpeakerModel eventModel);
       

    }
}
