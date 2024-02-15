﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.ReviewDTOs
{
	public class ResultGetReviewsByCarIdDTO
	{
		public int Id { get; set; }
		public string CustomerName { get; set; }
		public string CustomerImage { get; set; }
		public string CustomerComment { get; set; }
		public int RaytingValue { get; set; }
		public DateTime ReviewDate { get; set; }
		public int CarId { get; set; }
	}
}
