using Hmsapp.Models;
using System;

namespace Hmsapp.Repositories
{
    public interface IPracticeTimmingDayRepository
    {
        Guid SavePracticeTimmingDayRepository(PracticeTimmingDay practiceTimmingDay);
    }
}