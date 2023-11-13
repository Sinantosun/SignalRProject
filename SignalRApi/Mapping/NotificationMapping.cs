﻿using AutoMapper;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class NotificationMapping : Profile
	{
		public NotificationMapping()
		{
			CreateMap<Notification, CreateNotificationDto>().ReverseMap();
			CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
			CreateMap<Notification, ResultNotificationDto>().ReverseMap();
		}
	}
}
