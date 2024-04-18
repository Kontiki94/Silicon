<<<<<<< HEAD
﻿namespace Infrastructure.Models;
=======
﻿using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;
>>>>>>> 5093d5ff2a66cda979cdb5cac84ee5629d1021ef

public class CoursesModel
{
    // GeneralCourseInfo
    public int Id { get; set; }
    public bool IsBestSeller { get; set; } = false;
    public string? CourseImage { get; set; }
    public string? CourseImageAltText { get; set; }
    public string Title { get; set; } = null!;
    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
    public string? Rating { get; set; }
    public string? Reviews { get; set; }
    public string? Views { get; set; }
    public string? LikesInPercent { get; set; }
    public string? LikesInNumbers { get; set; }

    // AutherInfo
    public string? AuthorName { get; set; }
    public string? AutherBio { get; set; }
    public string? AuthorImage { get; set; }
    public string? AutherImageAltText { get; set; }
    public string? YouTubeSubscribers { get; set; }
    public string? FaceBookFollowers { get; set; }

    // CourseDetails
<<<<<<< HEAD
    public string? ShowcaseImage { get; set; }
=======
>>>>>>> 5093d5ff2a66cda979cdb5cac84ee5629d1021ef
    public string? CourseDescription { get; set; }
    public string? ViewHours { get; set; }
    public string? Articles { get; set; }
    public string? Resources { get; set; }
    public string? AccessTime { get; set; }
    public List<string>? ProgramDetailsTitle { get; set; }
<<<<<<< HEAD
    public List<string>? ProgramDetailsText { get; set; }
    public List<string>? LearnPoints { get; set; }

    public string? Category { get; set; }
=======
    public List <string>? ProgramDetailsText { get; set; }
    public List<string>? LearnPoints { get; set; }

    public string? Category { get; set; }

    // Implicit type converter
    public static implicit operator CoursesModel(CoursesEntity coursesEntity)
    {
        return new CoursesModel
        {
            Id = coursesEntity.Id,
            Title = coursesEntity.Title,
            IsBestSeller = coursesEntity.IsBestSeller,
            CourseImage = coursesEntity.CourseImage,
            CourseImageAltText = coursesEntity.CourseImageAltText,
            Price = coursesEntity.Price,
            DiscountPrice = coursesEntity.DiscountPrice,
            Rating = coursesEntity.Rating,
            Reviews = coursesEntity.Reviews,
            Views = coursesEntity.Views,
            LikesInPercent = coursesEntity.LikesInPercent,
            LikesInNumbers = coursesEntity.LikesInNumbers,
            AuthorName = coursesEntity.AuthorName,
            AutherBio = coursesEntity.AutherBio,
            AuthorImage = coursesEntity.AuthorImage,
            AutherImageAltText = coursesEntity.
            YouTubeSubscribers = coursesEntity.YouTubeSubscribers,
            FaceBookFollowers = coursesEntity.FaceBookFollowers,
            CourseDescription = coursesEntity.CourseDescription,
            ViewHours = coursesEntity.ViewHours,
            Resources = coursesEntity.Resources,
            AccessTime = coursesEntity.AccessTime,
            ProgramDetailsTitle = coursesEntity.ProgramDetailsTitle,
            ProgramDetailsText = coursesEntity.ProgramDetailsText,
            LearnPoints = coursesEntity.LearnPoints,
        };
    }
>>>>>>> 5093d5ff2a66cda979cdb5cac84ee5629d1021ef
}
