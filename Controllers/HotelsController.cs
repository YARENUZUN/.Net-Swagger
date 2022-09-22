using System;
using Microsoft.AspNetCore.Mvc;


namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
            private static readonly IHotelService _hotelService;
            public HotelsController(IHotelService hotelService)
            {
                _hotelService = hotelService;
            }

            /// <summary>
            /// Get All Hotel By id
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [HttpGet("{id}")]
            public IHotelService Get(int id)
            {
                Return _hotelService.GetHotelById(id);
            }

        /// <summary>
        /// Create an Hotel
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        public Hotel Post([FromBody]Hotel (hotel))
        {
            return _hotelService.CreateHotel(hotel);
        }

        /// <summary>
        /// Update the Hotel
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>

        [HttpPut]
        public Hotel Put([FromBody]Hotel (hotel))
        {
            return _hotelService.UpdateHotel(hotel);
        }

        /// <summary>
        /// Delete the Hotel
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Post(int id)
        {
            _hotelService.DeleteHotel(id);
        }



    }
}
