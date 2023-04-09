using SoftcrylicTech.Library.DBEntities;
using SoftcrylicTech.Model;
using System.Threading.Tasks;

namespace SoftcrylicTech.Library.Repositories.Interfaces
{
    public interface ITechConferenceRepo
    {
        Task<tblEventEntity> GetEventAsync(string title);
        Task<tblEventEntity> SaveEventAsync(EventModel eventModel);
        Task<tblEventEntity> UpdateEventAsync(EventModel eventModel);
        Task<tblEventEntity> DeleteEventAsync(int eventId); 
        Task<tblSpeakerEntity> SaveSpeakerAsync(SpeakerModel eventModel);
    }
}
