﻿using UnityEngine;
using OmiyaGames;
using UnityEngine.UI;
using System;

public class JoinMenu : IMenu
{
    public const string StartConnectionText = "Connect to IP Address:";
    public const FontStyle StartConnectionStyle = FontStyle.Normal;
    public const string WorkingOnConnectionText = "Connecting to {0}...";
    public const FontStyle WorkingOnConnectionStyle = FontStyle.Italic;
    public const string FailedConnectionText = "Connection to {0} Failed";
    public const FontStyle FailedConnectionStyle = FontStyle.Normal;

    [SerializeField]
    InputField ipAddress;
    [SerializeField]
    Button connectButton;
    [SerializeField]
    Text connectLabel;
    [SerializeField]
    Button backButton;

    string lastIpAddress;

    public override GameObject DefaultUi
    {
        get
        {
            return ipAddress.gameObject;
        }
    }

    public override Type MenuType
    {
        get
        {
            return Type.ManagedMenu;
        }
    }

    public override void Show(Action<IMenu> stateChanged)
    {
        base.Show(stateChanged);
        ipAddress.interactable = true;
        connectButton.interactable = true;
        connectLabel.text = StartConnectionText;
        connectLabel.fontStyle = StartConnectionStyle;
    }

    public void OnConnectClicked()
    {
        lastIpAddress = ipAddress.text;

        // Update UI
        ipAddress.interactable = false;
        connectButton.interactable = false;
        connectLabel.text = string.Format(WorkingOnConnectionText, lastIpAddress);
        connectLabel.fontStyle = WorkingOnConnectionStyle;

        // FIXME: attempt to connect

        // Play music
        Manager.ButtonClick.Play();
    }

    public void OnBackClicked()
    {
        // FIXME: cancel connection
        Hide();
        Manager.ButtonClick.Play();
    }

}
