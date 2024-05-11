using AutoMapper;
using Domain;
using MySpace.Application.User;
using MySpace.Application.Category;
using MySpace.Application.Space;
using MySpace.Application.Note;
using MySpace.Application.Member;
using MySpace.Application.Files;
using Domain.enums;
using MySpace.Application.Attachment;

namespace Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region User

        CreateMap<CreateUserRequest, Domain.User>();

        CreateMap<Domain.User, CreateUserResponse>();

        CreateMap<EditUserRequest, Domain.User>();
        CreateMap<Domain.User, EditUserResponse>();

        CreateMap<DeleteUserRequest, Domain.User>();
        CreateMap<Domain.User, DeleteUserResponse>();

        CreateMap<GetUserByIdRequest, Domain.User>();
        CreateMap<Domain.User, GetUserByIdResponse>();

        CreateMap<GetAllUsersRequest,Domain.User > ();
        CreateMap<Domain.User, GetAllUsersResponse>();

        #endregion

        #region Category

        CreateMap<NewCategory, Category>();
        CreateMap<Category, CategoryData>();

        CreateMap<EditCategory, Category>();
       
        CreateMap<DeleteCategoryRequest, Category>();
        CreateMap<Category, DeleteCategory>();

        CreateMap<CategoryDataRequest, Category > ();
        CreateMap<Category, OneCategoryData>();
     
        CreateMap<ListCategoriesRequest, Category>();
        CreateMap<Category, ListCategories>();

        #endregion

        #region Space
        CreateMap<CreateSpaceRequest, Domain.Space>()
            .ForMember(c => c.Categories, option => option.Ignore())
            .ForMember(c => c.Members, option => option.Ignore());
        CreateMap<Domain.Space, CreateSpaceResponse>();

        CreateMap<EditSpaceRequest, Domain.Space>();
        CreateMap<Domain.Space, EditSpaceResponse>();

        CreateMap<DeleteSpaceRequest, Domain.Space>();
        CreateMap<Domain.Space, DeleteSpaceResponse>();

        CreateMap<GetAllSpacesRequest, Domain.Space>();
        CreateMap<Domain.Space, GetAllSpacesResponse>();

        CreateMap<GetSpaceByIdRequest, Domain.Space>();
        CreateMap<Domain.Space, GetSpaceByIdResponse>();


        #endregion 

        #region Note

        CreateMap<NewNoteReq, Domain.Note>();
        CreateMap<Domain.Note, NewNoteData>();
            //.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category));

        CreateMap<EditNote, Domain.Note>();
       
        
        CreateMap<DeleteNoteRequest, Domain.Note>();
        CreateMap<Domain.Note, DeleteNote>();

        CreateMap<NoteDataRequest, Domain.Note>();
        CreateMap<Domain.Note, NoteData>();

        CreateMap<ListNotesRequest, Domain.Note>();
        CreateMap<Domain.Note, ListNotes>();

        #endregion

        #region member
        CreateMap<CreateMemberRequest, Domain.Member>();
       //.ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
        CreateMap<Domain.Member, CreateMemberResponse>();

        CreateMap<EditMember, Domain.Member>();

        CreateMap<DeleteMemberRequest, Domain.Member>();
        CreateMap<Domain.Member, DeleteMember>();

        CreateMap<GetAllMembersRequest, Domain.Member>();
        CreateMap<Domain.Member, GetAllMembersResponse>();

        CreateMap<GetMemberByIdRequest, Domain.Member>();
        CreateMap<Domain.Member, GetMemberByIdResponse>();

        CreateMap<Role, ProtoKeyValuePair>().ConvertUsing(src => new ProtoKeyValuePair { Key = src.Value, Value = src.Name });
        CreateMap<int, Role>().ConstructUsing(src => Role.FromValue(src));
        #endregion

        #region attachment

        CreateMap<NewAttachment, Domain.Attachment>();
        CreateMap<Domain.Attachment, NewAttachmentData>();

        CreateMap<EditAttachmentRequest, Domain.Attachment>();

        CreateMap<DeleteAttachmentRequest, Domain.Attachment>();
        CreateMap<Domain.Attachment, DeleteAttachmentData>();

        CreateMap<AttachDataRequest, Domain.Attachment>();
        CreateMap<Domain.Attachment, AttachmentData>();
        
        CreateMap<ListAttachmentsRequest, Domain.Attachment>();
        CreateMap<Domain.Attachment, ListAttachments>();
        #endregion

        #region Files

        CreateMap<NewFile, Domain.File>();
        CreateMap<Domain.File, FileData>();

        CreateMap<EditFileData, Domain.File>();

        CreateMap<DeleteFileDataRequest, Domain.File>();
        CreateMap<Domain.File, DeleteFileData>();

        CreateMap<FileDataRequest, Domain.File>();


        CreateMap<ListFileDataRequest, Domain.File>();
        CreateMap<Domain.File, ListFilesData>();
        #endregion

    }
}
