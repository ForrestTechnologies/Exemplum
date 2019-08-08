﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QandA.Features.Questions;

namespace QandA.Data.Configuration
{
	public class QuestionConfiguration : IEntityTypeConfiguration<Question>
	{
		public void Configure(EntityTypeBuilder<Question> builder)
		{
			builder.HasKey(q => q.Id);
		}
	}
}