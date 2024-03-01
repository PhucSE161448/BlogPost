CREATE TABLE "BlogPostComment"(
    "Id" INT NOT NULL,
    "Description" NVARCHAR(255) NOT NULL,
    "BlogPostId" INT NOT NULL,
    "AccountId" INT NOT NULL,
    "DateAdded" DATETIME NOT NULL
);
ALTER TABLE
    "BlogPostComment" ADD CONSTRAINT "blogpostcomment_id_primary" PRIMARY KEY("Id");
CREATE TABLE "BlogPost"(
    "Id" INT NOT NULL,
    "AccountId" INT NOT NULL,
    "Heading" NVARCHAR(255) NOT NULL,
    "PageTitle" NVARCHAR(255) NOT NULL,
    "Content" NVARCHAR(255) NOT NULL,
    "ShortDescription" NVARCHAR(255) NOT NULL,
    "Image_Url" NVARCHAR(255) NOT NULL,
    "Url_Handle" NVARCHAR(255) NOT NULL,
    "PublishedDate" DATETIME NOT NULL,
    "Visible" BIT NOT NULL DEFAULT '0'
);
ALTER TABLE
    "BlogPost" ADD CONSTRAINT "blogpost_id_primary" PRIMARY KEY("Id");
CREATE TABLE "BlogPostLike"(
    "Id" INT NOT NULL,
    "BlogPostId" INT NOT NULL,
    "AccountId" INT NOT NULL
);
ALTER TABLE
    "BlogPostLike" ADD CONSTRAINT "blogpostlike_id_primary" PRIMARY KEY("Id");
CREATE TABLE "Tags"(
    "Id" INT NOT NULL,
    "Name" NVARCHAR(255) NOT NULL,
    "BlogPostId" INT NOT NULL
);
ALTER TABLE
    "Tags" ADD CONSTRAINT "tags_id_primary" PRIMARY KEY("Id");
CREATE TABLE "Account"(
    "Id" INT NOT NULL,
    "Email" NVARCHAR(255) NOT NULL,
    "Name" NVARCHAR(255) NOT NULL,
    "Password" NVARCHAR(255) NOT NULL,
    "Role" NVARCHAR(255) NOT NULL,
    "Is_Delete" BIT NOT NULL DEFAULT '0'
);
ALTER TABLE
    "Account" ADD CONSTRAINT "account_id_primary" PRIMARY KEY("Id");
ALTER TABLE
    "BlogPostLike" ADD CONSTRAINT "blogpostlike_accountid_foreign" FOREIGN KEY("AccountId") REFERENCES "Account"("Id");
ALTER TABLE
    "Tags" ADD CONSTRAINT "tags_blogpostid_foreign" FOREIGN KEY("BlogPostId") REFERENCES "BlogPost"("Id");
ALTER TABLE
    "BlogPost" ADD CONSTRAINT "blogpost_accountid_foreign" FOREIGN KEY("AccountId") REFERENCES "Account"("Id");
ALTER TABLE
    "BlogPostLike" ADD CONSTRAINT "blogpostlike_blogpostid_foreign" FOREIGN KEY("BlogPostId") REFERENCES "BlogPost"("Id");
ALTER TABLE
    "BlogPostComment" ADD CONSTRAINT "blogpostcomment_blogpostid_foreign" FOREIGN KEY("BlogPostId") REFERENCES "BlogPost"("Id");
ALTER TABLE
    "BlogPostComment" ADD CONSTRAINT "blogpostcomment_accountid_foreign" FOREIGN KEY("AccountId") REFERENCES "Account"("Id");