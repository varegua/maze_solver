﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MazeSolver.Client.Core.mazeSolverService
{
    using System.Runtime.Serialization;
    using System;


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Difficulty", Namespace = "http://schemas.datacontract.org/2004/07/Ingesup.Maze.Server.Web.Models")]
    public enum Difficulty : int
    {

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Easy = 0,

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Medium = 1,

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Hard = 2,

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Extreme = 3,
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Game", Namespace = "http://schemas.datacontract.org/2004/07/Ingesup.Maze.Server.Web.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(MazeSolver.Client.Core.mazeSolverService.PlayerGame))]
    public partial class Game : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CreateDateField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CreatorField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MazeSolver.Client.Core.mazeSolverService.Difficulty DifficultyField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KeyField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MazeSolver.Client.Core.mazeSolverService.Maze MazeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MovePlayerMinIntervalField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CreateDate
        {
            get
            {
                return this.CreateDateField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CreateDateField, value) != true))
                {
                    this.CreateDateField = value;
                    this.RaisePropertyChanged("CreateDate");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Creator
        {
            get
            {
                return this.CreatorField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CreatorField, value) != true))
                {
                    this.CreatorField = value;
                    this.RaisePropertyChanged("Creator");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public MazeSolver.Client.Core.mazeSolverService.Difficulty Difficulty
        {
            get
            {
                return this.DifficultyField;
            }
            set
            {
                if ((this.DifficultyField.Equals(value) != true))
                {
                    this.DifficultyField = value;
                    this.RaisePropertyChanged("Difficulty");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Key
        {
            get
            {
                return this.KeyField;
            }
            set
            {
                if ((object.ReferenceEquals(this.KeyField, value) != true))
                {
                    this.KeyField = value;
                    this.RaisePropertyChanged("Key");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public MazeSolver.Client.Core.mazeSolverService.Maze Maze
        {
            get
            {
                return this.MazeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.MazeField, value) != true))
                {
                    this.MazeField = value;
                    this.RaisePropertyChanged("Maze");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MovePlayerMinInterval
        {
            get
            {
                return this.MovePlayerMinIntervalField;
            }
            set
            {
                if ((this.MovePlayerMinIntervalField.Equals(value) != true))
                {
                    this.MovePlayerMinIntervalField = value;
                    this.RaisePropertyChanged("MovePlayerMinInterval");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Maze", Namespace = "http://schemas.datacontract.org/2004/07/Ingesup.Maze.Server.Web.Models")]
    [System.SerializableAttribute()]
    public partial class Maze : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HeightField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int WidthField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Height
        {
            get
            {
                return this.HeightField;
            }
            set
            {
                if ((this.HeightField.Equals(value) != true))
                {
                    this.HeightField = value;
                    this.RaisePropertyChanged("Height");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Width
        {
            get
            {
                return this.WidthField;
            }
            set
            {
                if ((this.WidthField.Equals(value) != true))
                {
                    this.WidthField = value;
                    this.RaisePropertyChanged("Width");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "PlayerGame", Namespace = "http://schemas.datacontract.org/2004/07/Ingesup.Maze.Server.Web.Models")]
    [System.SerializableAttribute()]
    public partial class PlayerGame : MazeSolver.Client.Core.mazeSolverService.Game
    {

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MazeSolver.Client.Core.mazeSolverService.Player PlayerField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public MazeSolver.Client.Core.mazeSolverService.Player Player
        {
            get
            {
                return this.PlayerField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PlayerField, value) != true))
                {
                    this.PlayerField = value;
                    this.RaisePropertyChanged("Player");
                }
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Player", Namespace = "http://schemas.datacontract.org/2004/07/Ingesup.Maze.Server.Web.Models")]
    [System.SerializableAttribute()]
    public partial class Player : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CreateDateField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MazeSolver.Client.Core.mazeSolverService.Position CurrentPositionField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FinishDateField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FinishTimeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KeyField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NbMoveField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SecretMessageField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StartDateField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MazeSolver.Client.Core.mazeSolverService.Cell[] VisibleCellsField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CreateDate
        {
            get
            {
                return this.CreateDateField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CreateDateField, value) != true))
                {
                    this.CreateDateField = value;
                    this.RaisePropertyChanged("CreateDate");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public MazeSolver.Client.Core.mazeSolverService.Position CurrentPosition
        {
            get
            {
                return this.CurrentPositionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CurrentPositionField, value) != true))
                {
                    this.CurrentPositionField = value;
                    this.RaisePropertyChanged("CurrentPosition");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FinishDate
        {
            get
            {
                return this.FinishDateField;
            }
            set
            {
                if ((object.ReferenceEquals(this.FinishDateField, value) != true))
                {
                    this.FinishDateField = value;
                    this.RaisePropertyChanged("FinishDate");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FinishTime
        {
            get
            {
                return this.FinishTimeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.FinishTimeField, value) != true))
                {
                    this.FinishTimeField = value;
                    this.RaisePropertyChanged("FinishTime");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.IdField, value) != true))
                {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false)]
        public string Key
        {
            get
            {
                return this.KeyField;
            }
            set
            {
                if ((object.ReferenceEquals(this.KeyField, value) != true))
                {
                    this.KeyField = value;
                    this.RaisePropertyChanged("Key");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.NameField, value) != true))
                {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NbMove
        {
            get
            {
                return this.NbMoveField;
            }
            set
            {
                if ((this.NbMoveField.Equals(value) != true))
                {
                    this.NbMoveField = value;
                    this.RaisePropertyChanged("NbMove");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false)]
        public string SecretMessage
        {
            get
            {
                return this.SecretMessageField;
            }
            set
            {
                if ((object.ReferenceEquals(this.SecretMessageField, value) != true))
                {
                    this.SecretMessageField = value;
                    this.RaisePropertyChanged("SecretMessage");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StartDate
        {
            get
            {
                return this.StartDateField;
            }
            set
            {
                if ((object.ReferenceEquals(this.StartDateField, value) != true))
                {
                    this.StartDateField = value;
                    this.RaisePropertyChanged("StartDate");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public MazeSolver.Client.Core.mazeSolverService.Cell[] VisibleCells
        {
            get
            {
                return this.VisibleCellsField;
            }
            set
            {
                if ((object.ReferenceEquals(this.VisibleCellsField, value) != true))
                {
                    this.VisibleCellsField = value;
                    this.RaisePropertyChanged("VisibleCells");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Position", Namespace = "http://schemas.datacontract.org/2004/07/Ingesup.Maze.Server.Web.Models")]
    [System.SerializableAttribute()]
    public partial class Position : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int XField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int YField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int X
        {
            get
            {
                return this.XField;
            }
            set
            {
                if ((this.XField.Equals(value) != true))
                {
                    this.XField = value;
                    this.RaisePropertyChanged("X");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Y
        {
            get
            {
                return this.YField;
            }
            set
            {
                if ((this.YField.Equals(value) != true))
                {
                    this.YField = value;
                    this.RaisePropertyChanged("Y");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Cell", Namespace = "http://schemas.datacontract.org/2004/07/Ingesup.Maze.Server.Web.Models")]
    [System.SerializableAttribute()]
    public partial class Cell : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MazeSolver.Client.Core.mazeSolverService.CellType CellTypeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MazeSolver.Client.Core.mazeSolverService.Position PositionField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public MazeSolver.Client.Core.mazeSolverService.CellType CellType
        {
            get
            {
                return this.CellTypeField;
            }
            set
            {
                if ((this.CellTypeField.Equals(value) != true))
                {
                    this.CellTypeField = value;
                    this.RaisePropertyChanged("CellType");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public MazeSolver.Client.Core.mazeSolverService.Position Position
        {
            get
            {
                return this.PositionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PositionField, value) != true))
                {
                    this.PositionField = value;
                    this.RaisePropertyChanged("Position");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "CellType", Namespace = "http://schemas.datacontract.org/2004/07/Ingesup.Maze.Server.Web.Models")]
    public enum CellType : int
    {

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Empty = 0,

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Wall = 1,

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Start = 2,

        [System.Runtime.Serialization.EnumMemberAttribute()]
        End = 3,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Direction", Namespace = "http://schemas.datacontract.org/2004/07/Ingesup.Maze.Server.Web.Models")]
    public enum Direction : int
    {

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Up = 0,

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Right = 1,

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Down = 2,

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Left = 3,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "mazeSolverService.IGame")]
    public interface IGame
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IGame/CreateGame", ReplyAction = "http://tempuri.org/IGame/CreateGameResponse")]
        MazeSolver.Client.Core.mazeSolverService.PlayerGame CreateGame(MazeSolver.Client.Core.mazeSolverService.Difficulty difficulty, string playerName);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IGame/CreateGame", ReplyAction = "http://tempuri.org/IGame/CreateGameResponse")]
        System.Threading.Tasks.Task<MazeSolver.Client.Core.mazeSolverService.PlayerGame> CreateGameAsync(MazeSolver.Client.Core.mazeSolverService.Difficulty difficulty, string playerName);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IGame/LoadGame", ReplyAction = "http://tempuri.org/IGame/LoadGameResponse")]
        MazeSolver.Client.Core.mazeSolverService.Game LoadGame(string gameKey);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IGame/LoadGame", ReplyAction = "http://tempuri.org/IGame/LoadGameResponse")]
        System.Threading.Tasks.Task<MazeSolver.Client.Core.mazeSolverService.Game> LoadGameAsync(string gameKey);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IGame/ResetGame", ReplyAction = "http://tempuri.org/IGame/ResetGameResponse")]
        MazeSolver.Client.Core.mazeSolverService.Game ResetGame(string gameKey);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IGame/ResetGame", ReplyAction = "http://tempuri.org/IGame/ResetGameResponse")]
        System.Threading.Tasks.Task<MazeSolver.Client.Core.mazeSolverService.Game> ResetGameAsync(string gameKey);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IGame/AddPlayer", ReplyAction = "http://tempuri.org/IGame/AddPlayerResponse")]
        MazeSolver.Client.Core.mazeSolverService.Player AddPlayer(string gameKey, string playerName);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IGame/AddPlayer", ReplyAction = "http://tempuri.org/IGame/AddPlayerResponse")]
        System.Threading.Tasks.Task<MazeSolver.Client.Core.mazeSolverService.Player> AddPlayerAsync(string gameKey, string playerName);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IGame/MovePlayer", ReplyAction = "http://tempuri.org/IGame/MovePlayerResponse")]
        MazeSolver.Client.Core.mazeSolverService.Player MovePlayer(string gameKey, string playerKey, MazeSolver.Client.Core.mazeSolverService.Direction direction);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IGame/MovePlayer", ReplyAction = "http://tempuri.org/IGame/MovePlayerResponse")]
        System.Threading.Tasks.Task<MazeSolver.Client.Core.mazeSolverService.Player> MovePlayerAsync(string gameKey, string playerKey, MazeSolver.Client.Core.mazeSolverService.Direction direction);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameChannel : MazeSolver.Client.Core.mazeSolverService.IGame, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GameClient : System.ServiceModel.ClientBase<MazeSolver.Client.Core.mazeSolverService.IGame>, IGame
    {

        public GameClient()
        {
        }

        public GameClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public GameClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public GameClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public GameClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public MazeSolver.Client.Core.mazeSolverService.PlayerGame CreateGame(MazeSolver.Client.Core.mazeSolverService.Difficulty difficulty, string playerName)
        {
            return base.Channel.CreateGame(difficulty, playerName);
        }

        public System.Threading.Tasks.Task<MazeSolver.Client.Core.mazeSolverService.PlayerGame> CreateGameAsync(MazeSolver.Client.Core.mazeSolverService.Difficulty difficulty, string playerName)
        {
            return base.Channel.CreateGameAsync(difficulty, playerName);
        }

        public MazeSolver.Client.Core.mazeSolverService.Game LoadGame(string gameKey)
        {
            return base.Channel.LoadGame(gameKey);
        }

        public System.Threading.Tasks.Task<MazeSolver.Client.Core.mazeSolverService.Game> LoadGameAsync(string gameKey)
        {
            return base.Channel.LoadGameAsync(gameKey);
        }

        public MazeSolver.Client.Core.mazeSolverService.Game ResetGame(string gameKey)
        {
            return base.Channel.ResetGame(gameKey);
        }

        public System.Threading.Tasks.Task<MazeSolver.Client.Core.mazeSolverService.Game> ResetGameAsync(string gameKey)
        {
            return base.Channel.ResetGameAsync(gameKey);
        }

        public MazeSolver.Client.Core.mazeSolverService.Player AddPlayer(string gameKey, string playerName)
        {
            return base.Channel.AddPlayer(gameKey, playerName);
        }

        public System.Threading.Tasks.Task<MazeSolver.Client.Core.mazeSolverService.Player> AddPlayerAsync(string gameKey, string playerName)
        {
            return base.Channel.AddPlayerAsync(gameKey, playerName);
        }

        public MazeSolver.Client.Core.mazeSolverService.Player MovePlayer(string gameKey, string playerKey, MazeSolver.Client.Core.mazeSolverService.Direction direction)
        {
            return base.Channel.MovePlayer(gameKey, playerKey, direction);
        }

        public System.Threading.Tasks.Task<MazeSolver.Client.Core.mazeSolverService.Player> MovePlayerAsync(string gameKey, string playerKey, MazeSolver.Client.Core.mazeSolverService.Direction direction)
        {
            return base.Channel.MovePlayerAsync(gameKey, playerKey, direction);
        }
    }
}
