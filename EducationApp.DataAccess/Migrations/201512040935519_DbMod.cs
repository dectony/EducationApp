namespace EducationApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbMod : DbMigration
    {
        public override void Up()
        {
            

            RenameTable(name: "dbo.QuizQustions", newName: "QuizQuestions");
            DropForeignKey("dbo.QuizAnswers", "Question_QuizQustionId", "dbo.QuizQustions");
            RenameColumn(table: "dbo.QuizAnswers", name: "Question_QuizQustionId", newName: "Question_QuizQuestionId");
            RenameIndex(table: "dbo.QuizAnswers", name: "IX_Question_QuizQustionId", newName: "IX_Question_QuizQuestionId");
            DropPrimaryKey("dbo.QuizQuestions");
            DropColumn("dbo.QuizQuestions", "QuizQustionId");
            DropColumn("dbo.QuizQuestions", "Question");
            DropColumn("dbo.QuizQuestions", "RightAnswerId");

            AddColumn("dbo.QuizQuestions", "QuizQuestionId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.QuizQuestions", "QuestionDescriptor", c => c.String());
            AddColumn("dbo.QuizQuestions", "RightAnswerNumber", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.QuizQuestions", "QuizQuestionId");
            AddForeignKey("dbo.QuizAnswers", "Question_QuizQuestionId", "dbo.QuizQuestions", "QuizQuestionId");

        }
        
        public override void Down()
        {
            AddColumn("dbo.QuizQuestions", "RightAnswerId", c => c.Int(nullable: false));
            AddColumn("dbo.QuizQuestions", "Question", c => c.String());
            AddColumn("dbo.QuizQuestions", "QuizQustionId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.QuizAnswers", "Question_QuizQuestionId", "dbo.QuizQuestions");
            DropPrimaryKey("dbo.QuizQuestions");
            DropColumn("dbo.QuizQuestions", "RightAnswerNumber");
            DropColumn("dbo.QuizQuestions", "QuestionDescriptor");
            DropColumn("dbo.QuizQuestions", "QuizQuestionId");
            AddPrimaryKey("dbo.QuizQuestions", "QuizQustionId");
            RenameIndex(table: "dbo.QuizAnswers", name: "IX_Question_QuizQuestionId", newName: "IX_Question_QuizQustionId");
            RenameColumn(table: "dbo.QuizAnswers", name: "Question_QuizQuestionId", newName: "Question_QuizQustionId");
            AddForeignKey("dbo.QuizAnswers", "Question_QuizQustionId", "dbo.QuizQustions", "QuizQustionId");
            RenameTable(name: "dbo.QuizQuestions", newName: "QuizQustions");
        }
    }
}
