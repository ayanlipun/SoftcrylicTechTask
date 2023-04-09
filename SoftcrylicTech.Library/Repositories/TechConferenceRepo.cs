using Microsoft.EntityFrameworkCore;
using SoftcrylicTech.Library.DataContext;
using SoftcrylicTech.Library.DataFactories;
using SoftcrylicTech.Library.DBEntities;
using SoftcrylicTech.Library.Repositories.Interfaces;
using SoftcrylicTech.Model;
using System;
using System.Threading.Tasks;

namespace SoftcrylicTech.Library.Repositories
{
    public class TechConferenceRepo : ITechConferenceRepo
    {
        TechConfContext _context;
        DbFactory<TechConfContext> _dbFactory;
        public TechConferenceRepo(DbFactory<TechConfContext> dbFactory)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
            _context = _dbFactory.CreateTechConfContext();
        }

        public async Task<tblEventEntity> GetEventAsync(string title)
        {
            try
            {
                string sql = Sql.GetEventDetails(title);
                var returndata = _context.EventEntities.FromSqlRaw(sql);

                if (returndata == null)
                {
                    throw new Exception("tblEvent table return null data");
                }
                else
                {
                    return await returndata.AsNoTracking().FirstOrDefaultAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<tblEventEntity> SaveEventAsync(EventModel eventModel)
        {
            try
            {
                var insertEventData = _context.EventEntities.Add(ConvertToSpeakerEntity(eventModel));
                await _context.SaveChangesAsync();
                return insertEventData.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<tblEventEntity> UpdateEventAsync(EventModel eventModel)
        {
            try
            {
                var updateEventData = _context.EventEntities.Update(ConvertToSpeakerEntity(eventModel));
                await _context.SaveChangesAsync();
                return updateEventData.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<tblSpeakerEntity> SaveSpeakerAsync(SpeakerModel eventModel)
        {
            try
            {
                var insertSpeakerData = _context.SpeakerEntities.Add(ConvertToSpeakerEntity(eventModel));
                await _context.SaveChangesAsync();
                return insertSpeakerData.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private tblSpeakerEntity ConvertToSpeakerEntity(SpeakerModel speakerModel)
        {
            tblSpeakerEntity tblSpeaker = new tblSpeakerEntity();
            try
            {
                tblSpeaker.Name = speakerModel.Name;
                tblSpeaker.Bio = speakerModel.Bio;
                tblSpeaker.SocialLinks = speakerModel.SocialLinks;
                return tblSpeaker;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private tblEventEntity ConvertToSpeakerEntity(EventModel eventModel)
        {
            tblEventEntity tblEven = new tblEventEntity();
            try
            {
                tblEven.Title = eventModel.Title;
                tblEven.Description = eventModel.Description;
                tblEven.Date = eventModel.Date;
                tblEven.ModeOfEvent = eventModel.ModeOfEvent;
                tblEven.Venue = eventModel.Venue;
                tblEven.Website = eventModel.Website;
                tblEven.LinkForDetails = eventModel.LinkForDetails;
                tblEven.SpeakerId = eventModel.SpeakerId;

                return tblEven;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<tblEventEntity> DeleteEventAsync(int eventId)
        {
            var eventItem = await _context.EventEntities.FindAsync(eventId);

            _context.EventEntities.Remove(eventItem);
            await _context.SaveChangesAsync();

            return eventItem;
        }
    }
}
