using EventEase.Models;
using System.Collections.Generic;
using System.Linq;

namespace EventEase.Services
{
    public class AttendanceService
    {
        private List<AttendanceModel> Attendances = new List<AttendanceModel>();

        public void AddAttendance(AttendanceModel attendance)
        {
            attendance.Id = Attendances.Count > 0 ? Attendances.Max(a => a.Id) + 1 : 1;
            Attendances.Add(attendance);
        }

        public List<AttendanceModel> GetAttendancesByEventId(int eventId)
        {
            return Attendances.Where(a => a.EventId == eventId).ToList();
        }
    }
}
