using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMvcApp.Model
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; }

        [MaxLength(100)]
        public string Publisher { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public PriceOffer PriceOffer { get; set; }
    }

    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }

    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }

    public class BookAuthor
    {
        [Key, Column(Order = 1)]
        public int BookId { get; set; }

        [Key, Column(Order = 2)]
        public int AuthorId { get; set; }

        public int Order { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
    }

    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        [MaxLength(100)]
        public string VoterName { get; set; }

        public int NumStars { get; set; }

        public string Comment { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }

    public class PriceOffer
    {
        [Key]
        public int PriceOfferId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal NewPrice { get; set; }

        [MaxLength(200)]
        public string PromotionalText { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}
