﻿using System;
using SEIIApp.Shared.DomainDto;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Domain.CourseDomain;
using SEIIApp.Server.Domain.CourseDomain.CourseDomainStatus;
using SEIIApp.Server.Domain.UserDomain;
using SEIIApp.Shared.DomainDto.StatusDto;

namespace SEIIApp.Server.Domain
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Question, Question>();

            CreateMap<Quiz, QuizDto>()
                .ForMember(quizDto => quizDto.Questions,
                    opts => opts.MapFrom(obj => obj.Questions.ToArray()));
            CreateMap<QuizDto, Quiz>()
                .ForMember(quizObj => quizObj.Questions,
                    opts => opts.MapFrom(dto => dto.Questions.ToList()));


            CreateMap<Question, QuestionDto>()
                .ForMember(questionDto => questionDto.Answers,
                    opt => opt.MapFrom(obj => obj.Answers.ToArray()));
            CreateMap<QuestionDto, Question>()
                .ForMember(questionObj => questionObj.Answers,
                    opt => opt.MapFrom(dto => dto.Answers.ToList()));

            CreateMap<Answer, AnswerDto>();
            CreateMap<AnswerDto, Answer>();

            CreateMap<Student, StudentDto>()
                .ForMember(studentDto => studentDto.EnrolledCourses,
                    opts => opts.MapFrom(obj => obj.EnrolledCourses.ToArray()))
                .ForMember(x => x.QuestionStatusList,
                    y => y.MapFrom(z => z.QuestionStatusList.ToArray()));
            CreateMap<StudentDto, Student>()
                .ForMember(studentDto => studentDto.EnrolledCourses,
                    opts => opts.MapFrom(obj => obj.EnrolledCourses.ToList()))
                .ForMember(x => x.QuestionStatusList,
                    y => y.MapFrom(z => z.QuestionStatusList.ToList()));

            CreateMap<Content, ContentDto>();
            CreateMap<ContentDto, Content>();

            CreateMap<Chapter, ChapterDto>()
                .ForMember(x => x.ChapterContent,
                    y => y.MapFrom(z => z.ChapterContent.ToArray()));
            CreateMap<ChapterDto, Chapter>()
                .ForMember(x => x.ChapterContent,
                    y => y.MapFrom(z => z.ChapterContent.ToList()));

            CreateMap<Course, CourseDto>()
                .ForMember(x => x.Chapters,
                    y => y.MapFrom(z => z.Chapters.ToArray()));
            CreateMap<CourseDto, Course>()
                .ForMember(x => x.Chapters,
                    y => y.MapFrom(z => z.Chapters.ToList()));

            CreateMap<QuestionStatus, QuestionStatusDto>();
            CreateMap<QuestionStatusDto, QuestionStatus>();

            CreateMap<CourseStatus, CourseStatusDto>()
                .ForMember(x => x.ChapterStatusList,
                    y => y.MapFrom(z => z.ChapterStatusList.ToArray()));
            CreateMap<CourseStatusDto, CourseStatus>()
                .ForMember(x => x.ChapterStatusList,
                    y => y.MapFrom(z => z.ChapterStatusList.ToList()));

            CreateMap<QuizStatus, QuizStatusDto>();
            CreateMap<QuizStatusDto, QuizStatus>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Instructor, InstructorDto>();
            CreateMap<InstructorDto, Instructor>();

            CreateMap<ChapterStatus, ChapterStatusDto>();
            CreateMap<ChapterStatusDto, ChapterStatus>();
        }
    }
}