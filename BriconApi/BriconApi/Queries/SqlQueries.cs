namespace BriconApi.Queries
{
    public static class SqlQueries
    {
        public const string LastFileData = @"
            select top 1
              f.Id
            , f.FileName
            , f.FileTime
            , f.Header
            , f.ReadOutTime
            from FileData f
            order by id desc";

        public const string FancierByFileId = @"
            select
              fan.Id
            , fan.License
            , fan.Name
            , fan.Address
            , fan.ZipCode
            , fan.City
            , fan.CoordX
            , fan.CoordY
            , fan.Serial
            , fan.Distance
            , fan.DistanceUnit
            , fan.DistanceString
            , fan.FlightDesignated
            , fan.NaamUnicode
            , fan.GemeenteUnicode
            from Fancier fan
            where fan.FileData = @fileId";

        public const string PigeonsByFancierId = @"
            select
              p.Id
            , p.FancierId
            , p.ElBand
            , p.FedBand
            , p.ClubID
            , p.FlightID
            , p.Position1
            , p.Position2
            , p.Position3
            , p.Position4
            , p.Time
            , p.Evaluation
            , p.TeamNbr
            from Pigeon p
            where p.Fancier = @fancierId";

        public const string AddFancier = @"AddFancier";
        public const string AddPigeon = @"AddPigeon";
        public const string AddFileData = @"AddFileData";
    }
}