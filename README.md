# HumanoidHandPoseHelper
In Unity3d, Edit hand pose of humanoid character, and export it as animation clip.

Unity3Dで、humanoidキャラクターの手のポーズを編集して、AnimationClipとして書き出すスクリプトです。

Timelineを使って動画を作る際にキャラの手に表情を付けられるようにする用途を想定してます。

作成されたAnimationClipはHumanoid形式なので、他のキャラクターにも汎用的に使い回せます。

![screenshot](https://raw.github.com/wiki/umiyuki/HumanoidHandPoseHelper/humanoidhandposehelperimage.jpg)


## 使い方
1.リポジトリの中にあるHumanoidHandPoseHelperフォルダを自分のUnityプロジェクトに入れてください。

2.Humanoid形式のキャラクタのAnimatorコンポーネントが付いてるオブジェクトにHumanoidHandPoseHelperスクリプトを付けてください。

3.Unityエディタのプレイモードに入らなくても、編集モードの中で編集できます。

4.それぞれの指の関節に対応したスライダーを動かすとキャラクターの手のポーズが変化します。

5.Exportボタンを押す事で編集した手のポーズをAnimationClipに書き出せます。

左手のみ、右手のみ、両手の３パターンで書き出せます。

デフォルトではAssets/{ゲームオブジェクト名}_LeftHandPose.animみたいなパスで書き出します。AnimationClipNameに名前を設定するとその名前で書き出します。

6."Reset HandPose"ボタンを押すと編集した手のポーズをリセットできます。

7."IsShowEditHandPose"のチェックが付いてると編集ポーズをプレビューできます。

Timelineの編集中など、手のポーズをプレビューする必要が無い時はチェックを外してください。

チェックを外してもすぐに反映されませんが、他のオブジェクトを選択するなどすると反映されます。

注意点: エディタのプレイモードに入ったり、プレイモードから編集モードに戻ってくる時に編集したポーズがリセットされてしまいます。

### クレジット
Duo.Inc様の[EasyMotionRecorder](https://github.com/duo-inc/EasyMotionRecorder)のコードを参考にさせていただきました。
