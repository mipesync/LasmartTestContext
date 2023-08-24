import './index.css'
import { KonvaEventObject } from 'konva/lib/Node';
import { observer } from 'mobx-react-lite';
import { useEffect, useState } from 'react'
import { Stage, Layer, Circle } from 'react-konva';
import { randomiseColor } from './actions/colorRandomiser.action';
import { AddNewPointDto } from './dto/addNewPointDto';
import { PointsService } from './services/points.service';
import { GetAllPointsResponseDto } from './dto/responseDto/getAllPoints.responseDto';
import { mapCircleConfigToPoint } from './actions/mapPoint.action';
import { Html } from 'react-konva-utils';
import { Point } from './models/point.model';
import { ListView, ListViewFooter, ListViewHeader, ListViewItemProps } from '@progress/kendo-react-listview';
import sendSvg from './assets/send.svg';
import { AddNewCommentDto } from './dto/addNewCommentDto';
import { CommentsService } from './services/comments.service';

function App() {  
  const textInputStyles: string = 'bg-black/5 hover:bg-black/10 border-0 px-4 py-1  rounded-lg';

  let pointModels: Point[] = [];


  const [points, setPoints] = useState(pointModels);
  const [selectedPoint, setPointSelection] = useState<Point>();

  const [pointRadius, setRadius] = useState("");
  const [pointColor, setColor] = useState("");
  const [pointXLocation, setXLocation] = useState("");
  const [pointYLocation, setYLocation] = useState("");

  const [commentText, setCommentText] = useState("");

  const fetchPoints = async () =>{
    const response: GetAllPointsResponseDto = (await PointsService.getAllPoints()).data;

    if (response == undefined){
      setPoints([]);
    }
    else{
      setPoints(response.points!);
    }    
  }

  useEffect(() => {
      fetchPoints();
  });

  const addNewPoint = async (event?: KonvaEventObject<MouseEvent>) => {
    let point: AddNewPointDto = {
      x: event!.evt.x,
      y: event!.evt.y,
      color: randomiseColor(),
      radius: 15,
    };

    await PointsService.addNewPoint(point);
  };

  const deletePoint = async (event: KonvaEventObject<MouseEvent>) => {
    event.cancelBubble = true;

    const pointId: string = event.target.getAttr('id');
    await PointsService.deletePoint(Number.parseInt(pointId))
    setPointSelection(undefined);
  };

  const selectPoint = (event: KonvaEventObject<MouseEvent>) => {
    event.cancelBubble = true;
    const point: Point = mapCircleConfigToPoint(event)
    
    setPointSelection(point);

    setRadius(point.radius.toString());
    setColor(point.color!.toString());
    setXLocation(point.x.toString());
    setYLocation(point.y.toString());
  };

  const updatePoint = async (event: React.FormEvent<HTMLFormElement>) => {    
    event.preventDefault();
    
    let updatedPoint: Point = {
      id: selectedPoint?.id!,
      color: pointColor,
      radius: Number.parseInt(pointRadius),
      x: Number.parseInt(pointXLocation),
      y: Number.parseInt(pointYLocation),
    }

    await PointsService.updatePoint(updatedPoint);
  }

  const addComment = async (event: React.MouseEvent<HTMLImageElement, MouseEvent>) => {
    event.preventDefault();
    const comment: AddNewCommentDto = {
      pointId: selectedPoint?.id!,
      text: commentText,
      backgroundColor: randomiseColor()
    };

    await CommentsService.addNewComment(comment);
  };

  const commentsHeader = () => {
    return (
      <ListViewHeader className='font-bold'>
        Comments:
      </ListViewHeader>
    );
  };

  const commentsFooter = () => {
    return (
      <ListViewFooter>
        <form>
          <div className='flex flex-row gap-2'>
                  <input type='text' className={`${textInputStyles}`} value={commentText} onChange={e => setCommentText(e.target.value)} placeholder='Enter comment text...'/>
            <button >
              <img className='w-8' src={sendSvg} onClick={addComment}/>
            </button>
          </div>
        </form>
      </ListViewFooter>
    );
  };

  const commentRender = (props: ListViewItemProps) => {
    const item = props.dataItem;

    return (
      <p className='cursor-pointer hover:bg-black/5 p-1 rounded-lg' id={item.id}>{item.text}</p>
    );
  };

  return (
    <Stage style={{
      background: "#e5e5e5"
    }}
      width={window.innerWidth} 
      height={window.innerHeight}
      onDblClick={addNewPoint}
      onClick={() => setPointSelection(undefined)}>
      <Layer >
        <Html>
          {/*  !!!---ВЫНЕСТИ DIV В ОТДЕЛЬНЫЙ КОМПОНЕНТ CONTAINER---!!!  */selectedPoint &&
          <div className='flex flex-col justify-between h-screen'>
            <div className={`backdrop-blur-sm bg-black/10 rounded-br-[20px] p-5 w-fit`}> 
              <form className='flex flex-col gap-2.5' onSubmit={updatePoint}>
                <p className='font-bold'>Point properties:</p>
                <div className="">
                  <p>Color</p>
                  <input type='text' className={`${textInputStyles}`} value={pointColor} onChange={e => setColor(e.target.value)}/>
                </div>
                <div className="">
                  <p>Radius</p>
                  <input type='text' className={`${textInputStyles}`} value={pointRadius} onChange={e => setRadius(e.target.value)}/>
                </div>
                <div className="">
                  <p>X location</p>
                  <input type='text' className={`${textInputStyles}`} value={pointXLocation} onChange={e => setXLocation(e.target.value)}/>
                </div>
                <div className="">
                  <p>Y location</p>
                  <input type='text' className={`${textInputStyles}`} value={pointYLocation} onChange={e => setYLocation(e.target.value)}/>
                </div>
                <input className='mt-4 bg-[#8c8ecf] p-2 rounded-lg text-white' type='submit' value="Save changes"/>
              </form>              
            </div>
            <div className={`backdrop-blur-sm bg-black/10 rounded-tr-[20px] p-5 h-fit w-fit`}> 
              <ListView data={selectedPoint.comments} item={commentRender} header={commentsHeader} footer={commentsFooter} className=' flex flex-col gap-5'/>
            </div>
          </div>
          }
        </Html>
        {
          points && points.map((point) => (
            <Circle
              id={point.id.toString()}
              key={point.id}
              x={point.x}
              y={point.y}
              radius={point.radius}
              fill={point.color}
              onDblClick={deletePoint}
              onClick={selectPoint}/>
          ))
        }
      </Layer>
    </Stage>
  )
}

export default observer(App);