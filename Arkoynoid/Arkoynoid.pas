unit Arkoynoid;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Menus, ExtCtrls, MPlayer;

type
  TfrmArkoynoid = class(TForm)
    ImgArkoynoid: TImage;
    mnuArkoynoid: TMainMenu;
    mnuGame: TMenuItem;
    mnuNewGame: TMenuItem;
    mnuSeparator1: TMenuItem;
    mnuExit: TMenuItem;
    TmrArkoynoid: TTimer;
    TmrSeconds: TTimer;
    mp1: TMediaPlayer;
    mp2: TMediaPlayer;
    mp3: TMediaPlayer;
    procedure FormResize(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure TmrArkoynoidTimer(Sender: TObject);
    procedure ImgArkoynoidMouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure mnuExitClick(Sender: TObject);
    procedure mnuNewGameClick(Sender: TObject);
    procedure ImgArkoynoidClick(Sender: TObject);
    procedure TmrSecondsTimer(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

// =============================================================
  ClassObject = Class
  Private
  Public
    x, y, w, h:Integer; // Положение и размеры объекта.
    xv, yv:Integer; // Скорости движения объектов по осям OX и OY.
    Health:Integer; // Очки здоровья.
    Sound:TMediaPlayer;
    Background, Outline:TColor; // Цвет контура и фона объекта.
    Procedure Reflect(Obj:ClassObject; IsArk:Boolean); // Метод проверки на столкновение с другим объектом.
    Procedure Reset; Virtual; Abstract;
    Procedure Hit; Virtual; Abstract; // Метод попадания в объект.
    Procedure Move(ScrWidth, ScrHeight:Integer); // Метод движения объекта.
    Procedure Render(Bitmap:TBitmap); Virtual; Abstract; // Метод отрисовки объекта.
  End;

  ClassLevel = Class
  Private
  Public
    Background, Outline:TColor;
    Music:TMediaPlayer;
    Procedure Render(Bitmap:TBitmap);
  End;

  ClassInfo = Class
  Private
  Public
    Started:Boolean; // Флаг начала игры.
    Score:Longint; // Счет.
    Mode:Integer; // Режим игры (0 - обычный, 1 - молниеносный).
    Seconds:Longint;
    Balls, Bricks:Integer; // Счетчики текущего кол-ва шаров и кирпичей на сцене.
    Procedure Render(Canvas:TCanvas; x, y:Integer);
  End;

  ClassArkoynoid = Class(ClassObject)
  Private
  Public
    Procedure Reset; Override; // Метод сброса всех параметров объекта.
    Procedure Render(Bitmap:TBitmap); Override;
    Procedure Hit; Override;
  End;

  ClassBall = Class(ClassObject)
  Private
  Public
    OnArk:Boolean; // Флаг принадлежности к аркойноиду.
    Procedure Reset; Override;
    Procedure Render(Bitmap:TBitmap); Override;
    Procedure Hit; Override;
  End;

  ClassBrick = Class(ClassObject)
  Private
  Public
    Mode:Integer; // Тип кирпича.
    Procedure Reset; Override;
    Procedure Render(Bitmap:TBitmap); Override;
    Procedure Hit; Override;
  End;

  ClassFeature = Class(ClassObject)
  Private
  Public
    Mode:Integer; // Тип фишки.
    Procedure Reset; Override;
    Procedure Render(Bitmap:TBitmap); Override;
    Procedure Hit; Override;
  End;

Const
  MAX_BALLS = 8;
  MAX_FEATURES = 20;
  MAX_BRICKS = 95;

var
  frmArkoynoid: TfrmArkoynoid;
  i, j:Integer;
  State:Integer; // Состояние игрового процесса (0 - нет игры, 1 - игра, 2 - пауза, 3 - раунд выигран, 4 - раунд проигран).
  Info:ClassInfo;
  Level:ClassLevel;
  Ark:ClassArkoynoid;
  Ball:Array [1..MAX_BALLS] Of ClassBall;
  Feature:Array [1..MAX_FEATURES] Of ClassFeature;
  Brick:Array [1..MAX_BRICKS] Of ClassBrick;
  

implementation

{$R *.dfm}

Procedure LoadResources;
  Var i:Integer;
Begin
  // Инициализация информации:
  Info := ClassInfo.Create;
  // Инициализация уровня:
  Level := ClassLevel.Create;
  // Инициализация аркойноида:
  Ark := ClassArkoynoid.Create;
  Ark.Reset;
  // Инициализация мячей:
  For i := 1 To MAX_BALLS Do
  Begin
    Ball[i] := ClassBall.Create;
    Ball[i].Reset;
  End;
  // Инициализация фишек:
  For i := 1 To MAX_FEATURES Do
  Begin
    Feature[i] := ClassFeature.Create;
    Feature[i].Reset;
  End;
  // Инициализация кирпичей:
  For i:= 1 To MAX_BRICKS Do
  Begin
    Brick[i] := ClassBrick.Create;
    Brick[i].Reset;
  End;
  State := 1;
End;

Procedure DisposeResources;
Begin
  If (State > 0) Then
  Begin
    Level.Destroy;
    Ark.Destroy;
    For i := 1 To MAX_BALLS Do Ball[i].Destroy;
    For i := 1 To MAX_FEATURES Do Feature[i].Destroy;
    For i := 1 To MAX_BRICKS Do Brick[i].Destroy;
  End;
  State := 0;
End;

Procedure ClassInfo.Render(Canvas:TCanvas; x, y:Integer);
  Var Buffer:String;
Begin
  Canvas.Font.Color := RGB(250, 214, 67);
  Canvas.Font.Size := 15;
  Canvas.TextOut(x + 50, 10, 'Arkoynoid');

  Canvas.Font.Color := clWhite;
  Canvas.Font.Size := 10;
    
  Canvas.TextOut(x, y,       'Счет:');
  Canvas.TextOut(x, y + 80,  'Режим:');
  Canvas.TextOut(x, y + 160, 'Секунд прошло:');
  Canvas.TextOut(x, y + 370, 'Общий счет:');
    
  Canvas.Font.Size := 15;
  Str(Info.Score, Buffer);
  Canvas.TextOut(x, y + 20, Buffer);
  If (Info.Mode = 1) Then Canvas.TextOut(x, y + 100, 'Молниеносный') Else Canvas.TextOut(x, y + 100, 'Обычный');
  Str(Info.Seconds, Buffer);
  Canvas.TextOut(x, y + 180, Buffer);

  Canvas.Font.Size := 25;
  Canvas.Font.Color := RGB(250, 214, 67);
  Canvas.Rectangle(x - 1, y + 392, x + 190, y + 480);
  If (Info.Seconds <> 0) Then Str(Info.Score Div Info.Seconds, Buffer) Else Buffer := '0';
  Canvas.TextOut(x, y + 393, Buffer);
End;

// *** Код методов объекта:

Procedure ClassObject.Reflect(Obj:ClassObject; IsArk:Boolean);
Begin
  If ((Health > 0) And (Obj.Health > 0)) Then
    If ((X - Obj.w < Obj.x) And (Obj.x < x + w)) And ((y - Obj.h < Obj.y) And (Obj.y < y + h)) Then
    Begin
      // Изменяем направление движения столкнувшихся объектов:
      yv := yv*(-1);
      // Делаем сталкновение более плавным:
      if (Obj.y < y) Then
        y := Obj.y + Obj.h
      Else
        y := Obj.y - h;
      // Смещение по оси OX при соответствующем соударении с арком:
      if (IsArk) Then
      Begin
        xv := (Abs(x - Obj.x) * 10) Div Obj.w - 5;
      End;
      // Произошло столкновение двух объектов:
      Hit;
      Obj.Hit;
    End;
End;

Procedure ClassObject.Move(ScrWidth, ScrHeight:Integer);
Begin
  x := x + xv;
  y := y + yv;
  if (x < 0) then Begin xv := xv*(-1); x := 0; End;
  if (x > ScrWidth - w) then Begin xv := xv*(-1); x := ScrWidth - w; End;
  if (y < 0) Then Begin yv := yv*(-1); y := 0; End;
End;

// *** Код методов уровня:

Procedure ClassLevel.Render(Bitmap:TBitmap);
Begin
  Bitmap.Canvas.Brush.Color := Background;
  Bitmap.Canvas.Pen.Color := Outline;
  Bitmap.Canvas.Rectangle(0, 0, Bitmap.Width, Bitmap.Height);
  Bitmap.Canvas.Font.Color := clGray;
  Bitmap.Canvas.Font.Size := 6;
  Bitmap.Canvas.Brush.Color := RGB(0, 47, 94);
End;

// *** Код методов аркойноида:

Procedure ClassArkoynoid.Reset;
Begin
  Outline := clWhite;
  Background := RGB(176, 179, 249);
  w := 80;
  h := 14;
  xv := 1;
  yv := 0;
  Health := 1;
End;

Procedure ClassArkoynoid.Render(Bitmap:TBitmap);
Begin
  If (Health > 0) Then
  Begin    
    Bitmap.Canvas.Pen.Color := Outline;
    Bitmap.Canvas.Brush.Color := Background;
    Bitmap.Canvas.RoundRect(x, y, x + w, y + h, w, h - 8);
    Bitmap.Canvas.Brush.Color := RGB(0, 47, 94);
    Bitmap.Canvas.Pen.Color := RGB(0, 47, 94);
    Bitmap.Canvas.Ellipse(x + 6, y + 6, x + 9, y + 9);
    Bitmap.Canvas.Ellipse(x + w - 9, y + 6, x + w - 6, y + 9);
  End;
End;

Procedure ClassArkoynoid.Hit;
Begin
End;

// *** Код методов шара:

Procedure ClassBall.Reset;
Begin
  Health := 0;
  Outline := clWhite;
  Background := RGB(176, 179, 249);
  w := 15;
  h := 15;
  xv := 3;
  yv := 4;
End;

Procedure ClassBall.Render(Bitmap:TBitmap);
Begin
  If (Health > 0) Then
  Begin
    Bitmap.Canvas.Pen.Color := Outline;
    Bitmap.Canvas.Brush.Color := Background;
    Bitmap.Canvas.Ellipse(X, Y, X + w, Y + h);
  End;
End;

Procedure ClassBall.Hit;
Begin
End;

// *** Код методов фишки:

Procedure ClassFeature.Reset;
Begin
  Health := 0;
  Outline := clWhite;
  xv := 0;
  yv := 1;
  w := 20;
  h := 20;
End;

Procedure ClassFeature.Render(Bitmap:TBitmap);
Begin
  If (Health > 0) Then
  Begin
    Bitmap.Canvas.Pen.Color := Outline;
    Case Mode Of
      1: Begin // Увеличение вертикальной скорости мяча:
           Bitmap.Canvas.Brush.Color := clRed;
           Bitmap.Canvas.Ellipse(x, y, x + w, y + h);
           Bitmap.Canvas.Brush.Color := RGB(0, 47, 94);
           Bitmap.Canvas.Ellipse(x+3, y+3, x+w-3, y+h-3);
         End;
      2: Begin // Увеличение размера:
           Bitmap.Canvas.Brush.Color := clBlue;
           Bitmap.Canvas.Ellipse(x, y, x + w, y + h);
           Bitmap.Canvas.Brush.Color := RGB(0, 47, 94);
           Bitmap.Canvas.Ellipse(x+3, y+3, x+w-3, y+h-3);
         End;
    Else // Добавление шарика:
      Bitmap.Canvas.Brush.Color := clGreen;
      Bitmap.Canvas.Ellipse(x, y, x + w, y + h);
      Bitmap.Canvas.Brush.Color := RGB(0, 47, 94);
      Bitmap.Canvas.Ellipse(x+3, y+3, x+w-3, y+h-3);
      Mode := 0; // Сброс типа фишки для избежания ошибок.
    End;
  End;
End;

Procedure ClassFeature.Hit;
Begin
  Case (Mode) Of
    0: Begin // Новый мячик.
         For j := 1 To MAX_BALLS Do
           If (Ball[j].Health = 0) Then
           Begin
             Inc(Info.Balls);
             Ball[j].Reset;
             Ball[j].Health := 1;
             Ball[j].x := x;
             Ball[j].y := y;
             Break;
           End;
       End;
    1: Begin // Увеличение скорости.
           For j := 1 To MAX_BALLS Do
             If (Ball[j].Health > 0) Then Ball[j].yv := Round(Ball[j].yv * 1.15);
       End;
    2: Begin
         Ark.w := Ark.w + 10;
       End;
  End;
  Health := 0;
End;

// *** Код методов кирпича:

Procedure ClassBrick.Reset;
Begin
  Health := 0;
End;

Procedure ClassBrick.Render(Bitmap:TBitmap);
Begin
  If (Health > 0) Then
  Begin
    Case Mode Of
      1: Begin
           Bitmap.Canvas.Pen.Color := RGB(39, 95, 3);
           Bitmap.Canvas.Brush.Color := RGB(74, 176, 6);
           Bitmap.Canvas.Rectangle(x, y, x + w, y + h);
         End;
      2: Begin
           Bitmap.Canvas.Pen.Color := RGB(87, 87, 87);
           Bitmap.Canvas.Brush.Color := clWhite;
           Bitmap.Canvas.Rectangle(x, y, x + w, y + h);
           Bitmap.Canvas.Brush.Color := RGB(128, 128, 128);
           Bitmap.Canvas.Pen.Color := RGB(178, 178, 178);
           Bitmap.Canvas.Ellipse(x + 3, y + 3, x + 6, y + 6);
           Bitmap.Canvas.Ellipse(x + 3, y + h - 3, x + 6, y + h - 6);
           Bitmap.Canvas.Ellipse(x + w - 6, y + 3, x + w - 3, y + 6);
           Bitmap.Canvas.Ellipse(x + w - 6, y + h - 6, x + w - 3, y + h - 3);
         End;
    Else
      Bitmap.Canvas.Pen.Color := RGB(130, 65, 0);
      Bitmap.Canvas.Brush.Color := RGB(250, 214, 67);
      Bitmap.Canvas.Rectangle(x, y, x + w, y + h);
    End;
    
  End;
End;

Procedure ClassBrick.Hit;
Begin
  If (Mode <> 2) Then
  Begin
    Health := Health - 1;
    If (Health = 0) Then
    Begin
      Dec(Info.Bricks);
      If (Info.Bricks = 0) Then Ark.Health := 0;
      Info.Score := Info.Score + 30;
      Sound.Play;
    End;
  End; 
  Case Mode Of
  1: Begin // Кидаем сюрприз.
       Info.Score := Info.Score + 15;
       For j := 1 To MAX_FEATURES Do
         If (Feature[j].Health = 0) Then
         Begin
           Feature[j].Reset;
           Feature[j].Health := 1;
           Feature[j].x := x + 25;
           Feature[j].y := y;
           Feature[j].Mode := Random(3);
           Break;
         End;
     End;
   Else
     Info.Score := Info.Score + 5;
   End;
End;

// ------------------------------------------------------------
// Метод изменения размера формы:
procedure TfrmArkoynoid.FormResize(Sender: TObject);
begin
  ImgArkoynoid.Width := frmArkoynoid.ClientWidth - ImgArkoynoid.Left*2 - 200;
  ImgArkoynoid.Height := frmArkoynoid.ClientHeight - ImgArkoynoid.Top*2;
  ImgArkoynoid.Picture.Bitmap.Width := ImgArkoynoid.Width;
  ImgArkoynoid.Picture.Bitmap.Height := ImgArkoynoid.Height;
  Canvas.Brush.Color := clBlack;
  Canvas.Rectangle(0, 0, Width, Height);
end;

// Метод инициализации формы:
procedure TfrmArkoynoid.FormCreate(Sender: TObject);
begin
  State := 0;
  // Инициализация элементов формы:
  ImgArkoynoid.Left := 10;
  ImgArkoynoid.Top := 10;
  // Загрузка звуков:
  mp1.FileName := 'music01.mp3';
  mp1.Open;
  mp2.FileName := 'Sound03.mp3';
  mp2.Open;
  // Запуск новой игры:
  mnuNewGameClick(nil);
end;

// *** Вспомогательный метод для вывода текста в канвас:
Procedure TextOut(Canvas:TCanvas; x, y:Integer; Text:String; Color, BkColor:TColor; Size:Integer);
Begin
  Canvas.Font.Color := Color;
  Canvas.Font.Size := Size;
  Canvas.Brush.Color := BkColor;
  Canvas.TextOut(x, y, Text);
End;

// *** Метод создания новой игры:
procedure TfrmArkoynoid.mnuNewGameClick(Sender: TObject);
begin
  // Изменяем параметры формы и её элементов:
  TmrSeconds.Enabled := False;
  ImgArkoynoid.Cursor := crNone; // Прячем курсор.
  FormResize(nil);
  // Загружаем ресурсы:
  DisposeResources; // Очищаем старые ресурсы.
  LoadResources; // Инициализация игровых ресурсов.
  // Загрузка начальной информации:
  With Info Do
  Begin
    Mode := Random(2); // Выбираем случайный режим игры.
    Score := 0;
    Seconds := 0; // Всего секунд с начала раунда.
    Bricks := 0; // Нет кирпичей.
    Balls := 0; // Нет шаров.
    Started := False;
  End;
  // Загрузка уровня:
  Level.Background := RGB(0, 47, 94);
  Level.Outline := clWhite;
  // Загрузка аркойнойда:
  With Ark Do
  Begin
    x := ImgArkoynoid.Width Div 2 - 40;
    y := 500;
  End;
  // Загрузка шара:
  Inc(Info.Balls);
  With Ball[1] Do
  Begin
    OnArk := True;
    Health := 1;
  End;
  // Загрузка кирпичей:
  Randomize;
  For i := 1 To 13 Do
  Begin
    For j := 1 To 7 Do
      With Brick[(i-1)*7+j] Do
      Begin
        Sound := mp2;
        Outline := clGray;
        w := 65;
        h := 17;
        x := j * w;
        y := i * h;
        Mode := Random(3);
        If (Mode <> 2) Then Inc(Info.Bricks);
        Health := 1;
      End;
  End;
  // Работа со звуками:
  mp1.Stop;
  mp1.Position := 0;
  // Начало обработки уровня, т.е. сама игра:
  TmrArkoynoid.Enabled := True;
end;

// *** Метод выхода из игры:
procedure TfrmArkoynoid.mnuExitClick(Sender: TObject);
begin
  TmrArkoynoid.Enabled := True;
  DisposeResources;
  Close;
end;

// *** Метод щелканья мышкой по основному полю с игрой:
procedure TfrmArkoynoid.ImgArkoynoidClick(Sender: TObject);
begin
  For i := 1 To MAX_BALLS Do Ball[i].OnArk := False; // Отпускаем все шарики в полет.
  // Начинаем игру и подсчет всех очков после нажатия игрока на кнопку мыши:
  If (Info.Started = False) Then
  Begin
    mp1.Play;
    TmrSeconds.Enabled := True;
    Info.Started := True;
  End;
end;

// *** Метод управления аркойноидом:
procedure TfrmArkoynoid.ImgArkoynoidMouseMove(Sender: TObject;
  Shift: TShiftState; X, Y: Integer);
begin
  If (State = 1) Then
  Begin
    // Обновление положения аркойнойда:
    if (Ark.xv <> 0) Then
      if (X < 0) Then Ark.X := 0
      Else
        if (X > ImgArkoynoid.Width - Ark.w) Then Ark.X := ImgArkoynoid.Width - Ark.w Else Ark.X := X;
    if (Ark.yv <> 0) Then
      if (Y < 0) Then Ark.Y := 0
      Else
        if (y > ImgArkoynoid.Height - Ark.h) Then Ark.y := ImgArkoynoid.Height - Ark.h Else Ark.Y := Y;
  End;
end;

// *** Таймер для отсчета секунд:
procedure TfrmArkoynoid.TmrSecondsTimer(Sender: TObject);
begin
  Inc(Info.Seconds); // Прошла очередная секунда.
end;

// *** Метод обновления экрана (геймплэй и сам игровой процесс):
procedure TfrmArkoynoid.TmrArkoynoidTimer(Sender: TObject);
begin
  // Проверка состояния игры:
  If (Info.Bricks = 0) Then State := 3 Else If (Info.Balls = 0) Then State := 4;
  // Выполнение действий в соответствии с состоянием:
  If (State > 2) Then // Игра закончена по одной из двух причин:
  Begin
    ImgArkoynoid.Cursor := crDefault; // Восстанавливаем курсор.
    TmrArkoynoid.Enabled := False; // Отключаем основной таймер.
    TmrSeconds.Enabled := False; // Отключаем отсчет секунд.
    mp1.Stop; // Отключаем музыку, если таковая была.
    mp1.Position := 0;
    If (State = 4) Then // Игрок проиграл:
    Begin
      mp3.FileName := 'Sound02.mp3';
      mp3.Open;
      mp3.Play;
    End Else
      If (State = 3) Then // Игрок выиграл:
      Begin
        mp3.FileName := 'Sound01.mp3';
        mp3.Open;
        mp3.Play;
      End;
  End Else Begin
    If ((Info.Started = True) And (mp1.Position = mp1.Length)) Then Begin mp1.Position := 0; mp1.Play; End;
    // Прорисовка информации:
    Info.Render(Canvas, ImgArkoynoid.Left + ImgArkoynoid.Width + 13, 80);
    // Прорисовка уровня:
    Level.Render(ImgArkoynoid.Picture.Bitmap);
    // Обновление положения мячей:
    For i := 1 To MAX_BALLS Do
    Begin
      If (Ball[i].Health > 0) Then
      Begin
        If (Ball[i].OnArk) Then
        Begin
          Ball[i].x := Ark.x;
          Ball[i].y := Ark.y - Ball[i].h;
        End Else Begin
          Ball[i].Move(ImgArkoynoid.Width, ImgArkoynoid.Height);
          If ((Ball[i].y > ImgArkoynoid.Height) Or (Ball[i].y < -50)) Then
          Begin
            Ball[i].Health := 0;
            Dec(Info.Balls);
            If (Info.Balls = 0) Then Ark.Health := 0;
          End Else Begin
            Ball[i].Reflect(Ark, True);
            For j := 1 To MAX_BRICKS Do Ball[i].Reflect(Brick[j], False);
            For j := 1 To MAX_BALLS Do If (i <> j) Then Ball[i].Reflect(Ball[j], False);
            // Зверский режим (все объекты взаимодействуют):
            If (Info.Mode = 1) Then
              For j := 1 To MAX_FEATURES Do Ball[i].Reflect(Feature[j], False);
          End;
        End;
        Ball[i].Render(ImgArkoynoid.Picture.Bitmap);
      End;
    End;
    // Обновление кирпичей:
    For i := 1 To MAX_BRICKS Do Brick[i].Render(ImgArkoynoid.Picture.Bitmap);
    // Обновление фишек:
    For i := 1 To MAX_FEATURES Do
    Begin
      Feature[i].Move(ImgArkoynoid.Width, ImgArkoynoid.Height);
      Feature[i].Reflect(Ark, False);
      
      Feature[i].Render(ImgArkoynoid.Picture.Bitmap);
      If (Feature[i].y > ImgArkoynoid.Height) Then Feature[i].Health := 0; // Фишка вылетела за границы экрана (освобождаем ресурс).
    End;
    // Прорисовка аркойнойда:
    For i := 1 To MAX_BRICKS Do Ark.Reflect(Brick[i], False);
    Ark.Render(ImgArkoynoid.Picture.Bitmap);
  End;
end;

end.
