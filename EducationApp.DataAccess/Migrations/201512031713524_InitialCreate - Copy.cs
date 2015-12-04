namespace EducationApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuizAnswers",
                c => new
                    {
                        QuizAnswerId = c.Int(nullable: false, identity: true),
                        Answer = c.String(),
                        Question_QuizQustionId = c.Int(),
                    })
                .PrimaryKey(t => t.QuizAnswerId)
                .ForeignKey("dbo.QuizQustions", t => t.Question_QuizQustionId)
                .Index(t => t.Question_QuizQustionId);
            
            CreateTable(
                "dbo.QuizQustions",
                c => new
                    {
                        QuizQustionId = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        RightAnswerId = c.Int(nullable: false),
                        Quiz_QuizId = c.Int(),
                    })
                .PrimaryKey(t => t.QuizQustionId)
                .ForeignKey("dbo.Quizs", t => t.Quiz_QuizId)
                .Index(t => t.Quiz_QuizId);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        QuizId = c.Int(nullable: false, identity: true),
                        QuizName = c.String(),
                        Theme_ThemeId = c.Int(),
                    })
                .PrimaryKey(t => t.QuizId)
                .ForeignKey("dbo.Themes", t => t.Theme_ThemeId)
                .Index(t => t.Theme_ThemeId);
            
            CreateTable(
                "dbo.Themes",
                c => new
                    {
                        ThemeId = c.Int(nullable: false, identity: true),
                        ThemeName = c.String(),
                        ContentFilePath = c.String(),
                    })
                .PrimaryKey(t => t.ThemeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quizs", "Theme_ThemeId", "dbo.Themes");
            DropForeignKey("dbo.QuizQustions", "Quiz_QuizId", "dbo.Quizs");
            DropForeignKey("dbo.QuizAnswers", "Question_QuizQustionId", "dbo.QuizQustions");
            DropIndex("dbo.Quizs", new[] { "Theme_ThemeId" });
            DropIndex("dbo.QuizQustions", new[] { "Quiz_QuizId" });
            DropIndex("dbo.QuizAnswers", new[] { "Question_QuizQustionId" });
            DropTable("dbo.Themes");
            DropTable("dbo.Quizs");
            DropTable("dbo.QuizQustions");
            DropTable("dbo.QuizAnswers");
        }
    }
}
