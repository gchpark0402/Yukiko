## Unity XR interaction toolkit을 활용한 Oculus Quest 2 Japanese VR 공포 게임
---
#### 프로젝트 소개

* 총 2스테이지로 지하 동굴 스테이지와 지상 가옥 스테이지로 나뉘어져 있습니다.
  
* 직접 움직여 이동할 수도 있지만 넓은 장소를 가상현실로 구현하였기 때문에 현실의 제약에서 벗어날 수 있도록 컨트롤러 Thumbstick로 캐릭터를 이동 가능하게 구현하였습니다.
  
* 컨트롤러를 통해 물체와 상호작용을 하면서 귀신을 피해 공간을 탈출해야 합니다.
 
---
#### 기능 구현

* 게임 내에서 XR interaction toolkit을 사용하여 Unity - Oculus Quest 2 연결, 플레이
* 게임 내의 물체 상호작용 구현
  * trigger button으로 문을 grab하여 열거나 물건을 grab하여 습득
  * 무기를 습득해서 귀신에게 공격 가능
* 플레이어를 인식하고 nav mesh agent를 통해 목표지점까지 이동하는 귀신 ai 구현
  *  사실성을 추가하기 위해 귀신 발자국 소리 추가와 3d sound 적용
*  Oculus quest 2에 맞는 간단한 ui 생성
*  가상현실에서 움직일 경우 발생하는 멀미를 줄이기 위해 터널링 비네팅(Tunneling vignetting) 사용
  * 화면 주변부의 명도, 채도를 낮추는 필터 사용
* 캐릭터 움직임의 현실성을 위해 발자국 3d sound, 다리 애니메이션 ik 적용
* Cinema Scene1(컷신1 - 차안) -> Cinema Scene2(컷신2 - 폐가 입장 전) -> Cave Scene -> House Scene

---
#### 영상

* <https://youtu.be/watch?v=V8NwKB-RL3k>
