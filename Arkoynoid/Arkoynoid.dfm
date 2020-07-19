object frmArkoynoid: TfrmArkoynoid
  Left = 316
  Top = 235
  Width = 800
  Height = 615
  Caption = 'Arkoynoid 1.0'
  Color = clBlack
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  Menu = mnuArkoynoid
  OldCreateOrder = False
  OnCreate = FormCreate
  OnResize = FormResize
  PixelsPerInch = 96
  TextHeight = 13
  object ImgArkoynoid: TImage
    Left = 8
    Top = 8
    Width = 545
    Height = 409
    OnClick = ImgArkoynoidClick
    OnMouseMove = ImgArkoynoidMouseMove
  end
  object mp1: TMediaPlayer
    Left = 8
    Top = 424
    Width = 253
    Height = 33
    Visible = False
    TabOrder = 0
  end
  object mp2: TMediaPlayer
    Left = 16
    Top = 432
    Width = 253
    Height = 33
    Visible = False
    TabOrder = 1
  end
  object mp3: TMediaPlayer
    Left = 24
    Top = 440
    Width = 253
    Height = 33
    Visible = False
    TabOrder = 2
  end
  object mnuArkoynoid: TMainMenu
    Left = 8
    Top = 8
    object mnuGame: TMenuItem
      Caption = #1048#1075#1088#1072
      object mnuNewGame: TMenuItem
        Caption = #1053#1072#1095#1072#1090#1100' &'#1085#1086#1074#1091#1102
        OnClick = mnuNewGameClick
      end
      object mnuSeparator1: TMenuItem
        Caption = '-'
      end
      object mnuExit: TMenuItem
        Caption = #1042#1099'&'#1093#1086#1076
        OnClick = mnuExitClick
      end
    end
  end
  object TmrArkoynoid: TTimer
    Enabled = False
    Interval = 10
    OnTimer = TmrArkoynoidTimer
    Left = 40
    Top = 8
  end
  object TmrSeconds: TTimer
    Enabled = False
    OnTimer = TmrSecondsTimer
    Left = 72
    Top = 8
  end
end
